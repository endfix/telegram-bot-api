using System.Net;
using Endfix.Telegram.BotAPI.Extensions;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Example.Webhook;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder     = WebApplication.CreateBuilder(args);
        builder.Configuration.AddUserSecrets<Program>(optional: true);
        var app         = builder.Build();

        var token       = GetToken(builder.Configuration);
        var webhookUrl  = builder.Configuration.GetSection("TelegramBotApi:WebhookUrl").Value!;
        var serverSecretToken = builder.Configuration.GetSection("TelegramBotApi:SecretToken").Value!;

        var handler = new SocketsHttpHandler
        {
            PooledConnectionLifetime = TimeSpan.FromSeconds(5),
            MaxConnectionsPerServer = 10
        };

        var client = new HttpClient(handler)
        {
            Timeout = TimeSpan.FromMinutes(5)
        };

        var api = new BotApiClient(token, client);

        _ = Task.Run(async () =>
        {
            try
            {
                var setWebhookResult = await api.SetWebhookAsync(
                    url: webhookUrl,
                    maxConnections: 100,
                    secretToken: serverSecretToken);

                app.Logger.LogInformation($"setWebhook: {(setWebhookResult ? "success" : "failure")}");

                var webhookInfo = await api.GetWebhookInfoAsync();
                app.Logger.LogInformation($"webhookInfo: {webhookInfo.Serialize(true)}");
            }
            catch (Exception e)
            {
                app.Logger.LogError(e, "Error setting webhook");
            }
        });

        _ = app.MapPost("/webhook/update", async (context) =>
        {
            var clientSecretToken = context.Request.Headers["X-Telegram-Bot-Api-Secret-Token"].ToString();
            if (!serverSecretToken.Equals(clientSecretToken))
            {
                context.Response.StatusCode = (int) HttpStatusCode.Forbidden;
                return;
            }

            var update = await context.Request.ReadFromJsonAsync<Update>(JsonSerializerExtensions.Options);
            if (update != null)
            {
                try
                {
                    // echo (ping - pong)
                    var result = await api.SendMessageAsync(
                        chatId: update.Message!.Chat.Id,
                        text: update.Message?.Text ?? string.Empty);
                }
                catch (Exception e)
                {
                    app.Logger.LogError(e, "Error processing update");
                }
            }

            Results.Ok();
        });

        app.Run();
    }

    private static string GetToken(IConfiguration config)
    {
        var token = Environment.GetEnvironmentVariable("TELEGRAM_BOT_TOKEN")
            ?? config["TELEGRAM_BOT_TOKEN"]
            ?? config["TelegramBotApi:Token"];

        return string.IsNullOrWhiteSpace(token) || token == "<bot-token>"
            ? throw new InvalidOperationException("Set TELEGRAM_BOT_TOKEN using environment variables or .NET User Secrets.")
            : token;
    }
}
