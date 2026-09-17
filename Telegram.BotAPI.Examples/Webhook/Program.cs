using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Endfix.Telegram.BotAPI;
using Endfix.Telegram.BotAPI.Enums;
using Endfix.Telegram.BotAPI.Exceptions;
using Endfix.Telegram.BotAPI.Extensions;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Example.Webhook;

internal static class Program
{
    private const string SecretHeaderName = "X-Telegram-Bot-Api-Secret-Token";

    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Configuration.AddUserSecrets(typeof(Program).Assembly, optional: true);

        builder.Services.AddSingleton(_ => new HttpClient(new SocketsHttpHandler
        {
            PooledConnectionLifetime = TimeSpan.FromMinutes(5),
            MaxConnectionsPerServer = 10
        })
        {
            Timeout = TimeSpan.FromMinutes(5)
        });
        builder.Services.AddSingleton<IBotApiClient>(services => new BotApiClient(
            token: GetToken(services.GetRequiredService<IConfiguration>()),
            services.GetRequiredService<HttpClient>(),
            logger: services.GetRequiredService<ILogger<IBotApiClient>>()));
        builder.Services.AddScoped<UpdateProcessor>();
        builder.Services.AddHostedService<TelegramWebhookService>();

        var app = builder.Build();
        _ = GetToken(app.Configuration);
        _ = GetWebhookUrl(app.Configuration);
        var secretToken = GetSecretToken(app.Configuration);

        app.MapPost("/webhook/update", HandleUpdateAsync)
            .AddEndpointFilter(new TelegramSecretTokenFilter(secretToken));

        await app.RunAsync();
    }

    private static async Task<IResult> HandleUpdateAsync(
        HttpContext context,
        IBotApiClient api,
        IServiceScopeFactory scopeFactory,
        CancellationToken cancellationToken)
    {
        Update? update;
        try
        {
            update = await context.Request.ReadFromJsonAsync<Update>(
                JsonSerializerExtensions.Options,
                cancellationToken);
        }
        catch (JsonException)
        {
            return Results.BadRequest();
        }

        if (update is null)
        {
            return Results.BadRequest();
        }

        await using var scope = scopeFactory.CreateAsyncScope();
        var processor = scope.ServiceProvider.GetRequiredService<UpdateProcessor>();
        await processor.ProcessAsync(api, update, cancellationToken);
        return Results.Ok();
    }

    private static string GetToken(IConfiguration config)
    {
        var token = Environment.GetEnvironmentVariable("TELEGRAM_BOT_TOKEN")
            ?? config["TELEGRAM_BOT_TOKEN"]
            ?? config["TelegramBotApi:Token"];

        return string.IsNullOrWhiteSpace(token) || token == "<bot-token>"
            ? throw new InvalidOperationException(
                "Set TELEGRAM_BOT_TOKEN using an environment variable or .NET User Secrets.")
            : token;
    }

    private static string GetWebhookUrl(IConfiguration config)
    {
        var url = Environment.GetEnvironmentVariable("TELEGRAM_WEBHOOK_URL")
            ?? config["TELEGRAM_WEBHOOK_URL"]
            ?? config["TelegramBotApi:WebhookUrl"];

        if (string.IsNullOrWhiteSpace(url) ||
            url.Contains('<', StringComparison.Ordinal) ||
            url.Contains("example.invalid", StringComparison.OrdinalIgnoreCase) ||
            url.Contains("yourdomain", StringComparison.OrdinalIgnoreCase) ||
            !url.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
        {
            throw new InvalidOperationException(
                "Set TelegramBotApi:WebhookUrl (or TELEGRAM_WEBHOOK_URL) to the public HTTPS URL of /webhook/update.");
        }

        return url;
    }

    private static string GetSecretToken(IConfiguration config)
    {
        var secret = Environment.GetEnvironmentVariable("TELEGRAM_WEBHOOK_SECRET")
            ?? config["TELEGRAM_WEBHOOK_SECRET"]
            ?? config["TelegramBotApi:SecretToken"];

        return string.IsNullOrWhiteSpace(secret) || secret.Contains('<', StringComparison.Ordinal)
            ? throw new InvalidOperationException(
                "Set TelegramBotApi:SecretToken (or TELEGRAM_WEBHOOK_SECRET). Telegram sends it as X-Telegram-Bot-Api-Secret-Token.")
            : secret;
    }

    private sealed class TelegramWebhookService(
        IBotApiClient api,
        IConfiguration config,
        ILogger<TelegramWebhookService> logger) : IHostedLifecycleService
    {
        public Task StartingAsync(CancellationToken cancellationToken) => Task.CompletedTask;

        public Task StartAsync(CancellationToken cancellationToken) => Task.CompletedTask;

        public async Task StartedAsync(CancellationToken cancellationToken)
        {
            var webhookUrl = GetWebhookUrl(config);
            var secretToken = GetSecretToken(config);
            var bot = await api.GetMeAsync(cancellationToken);

            await api.SetWebhookAsync(
                url: webhookUrl,
                secretToken: secretToken,
                cancellationToken: cancellationToken);

            var webhookInfo = await api.GetWebhookInfoAsync(cancellationToken);
            logger.LogInformation(
                "Registered webhook {WebhookUrl} for @{Username} ({BotId}). Pending updates: {PendingCount}.",
                webhookUrl,
                bot.Username,
                bot.Id,
                webhookInfo.PendingUpdateCount);
        }

        public async Task StoppingAsync(CancellationToken cancellationToken)
        {
            try
            {
                await api.DeleteWebhookAsync(dropPendingUpdates: false, cancellationToken);
                logger.LogInformation("Removed webhook without dropping pending updates.");
            }
            catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
            {
            }
            catch (Exception exception)
            {
                logger.LogWarning(exception, "Could not delete webhook during shutdown.");
            }
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;

        public Task StoppedAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }

    private sealed class UpdateProcessor(ILogger<UpdateProcessor> logger)
    {
        public async Task ProcessAsync(
            IBotApiClient api,
            Update update,
            CancellationToken cancellationToken)
        {
            logger.LogInformation(
                "Update {UpdateId} ({UpdateType}): {UpdateJson}",
                update.UpdateId,
                update.Type,
                update.Serialize(writeIndented: false));

            try
            {
                if (update.Type == UpdateType.Message &&
                    update.Message is { Text: { Length: > 0 } text, Chat.Id: var chatId })
                {
                    await api.SendMessageAsync(chatId, text, cancellationToken: cancellationToken);
                }
            }
            catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
            {
            }
            catch (ApiRequestException exception)
            {
                logger.LogError(
                    exception,
                    "Telegram rejected update {UpdateId}: {ErrorCode} {Description}",
                    update.UpdateId,
                    exception.ErrorCode,
                    exception.Message);
            }
            catch (Exception exception)
            {
                logger.LogError(exception, "Failed to process update {UpdateId}", update.UpdateId);
            }
        }
    }

    private sealed class TelegramSecretTokenFilter(string expectedSecret) : IEndpointFilter
    {
        public async ValueTask<object?> InvokeAsync(
            EndpointFilterInvocationContext context,
            EndpointFilterDelegate next)
        {
            var provided = context.HttpContext.Request.Headers[SecretHeaderName].ToString();
            if (!SecretEquals(expectedSecret, provided))
            {
                return Results.Forbid();
            }

            return await next(context);
        }

        private static bool SecretEquals(string expected, string provided)
        {
            var expectedBytes = Encoding.UTF8.GetBytes(expected);
            var providedBytes = Encoding.UTF8.GetBytes(provided);
            if (expectedBytes.Length != providedBytes.Length)
            {
                return false;
            }

            return CryptographicOperations.FixedTimeEquals(expectedBytes, providedBytes);
        }
    }
}
