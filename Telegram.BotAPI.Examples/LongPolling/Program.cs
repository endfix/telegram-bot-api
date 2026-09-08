using Endfix.Telegram.BotAPI.Enums;
using Endfix.Telegram.BotAPI.Exceptions;
using Endfix.Telegram.BotAPI.Extensions;
using Endfix.Telegram.BotAPI.Types;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Endfix.Telegram.BotAPI.Example.LongPolling;

internal class Program
{
    private const string DefaultMiniAppUrl = "https://endfix.github.io/telegram-bot-api/";

    static async Task Main(string[] args)
    {
        using var loggerFactory = LoggerFactory.Create(builder => builder
            .SetMinimumLevel(LogLevel.Debug)
            .AddSimpleConsole(options =>
            {
                options.SingleLine = true;
                options.TimestampFormat = "HH:mm:ss ";
            }));
        var logger = loggerFactory.CreateLogger<Program>();

        using var cancellation = new CancellationTokenSource();
        Console.CancelKeyPress += (_, eventArgs) =>
        {
            eventArgs.Cancel = true;
            cancellation.Cancel();
        };

        try
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddUserSecrets<Program>(optional: true)
                .Build();

            using var handler = new SocketsHttpHandler
            {
                PooledConnectionLifetime = TimeSpan.FromSeconds(5),
                MaxConnectionsPerServer = 10
            };
            using var httpClient = new HttpClient(handler)
            {
                Timeout = TimeSpan.FromMinutes(5)
            };
            using var api = new BotApiClient(
                token: GetToken(config),
                httpClient,
                logger: loggerFactory.CreateLogger<IBotApiClient>());

            var bot = await api.GetMeAsync(cancellation.Token);
            logger.LogInformation("Starting event harness for @{Username} ({BotId})", bot.Username, bot.Id);

            await api.DeleteWebhookAsync(dropPendingUpdates: false, cancellationToken: cancellation.Token);
            logger.LogInformation(
                "Long polling is active. Send /probe or /webapp to @{Username}; press Ctrl+C to stop.",
                bot.Username);

            api.OnUpdate += async (_, update, cancellationToken) =>
            {
                logger.LogInformation(
                    "Update {UpdateId} ({UpdateType}): {UpdateJson}",
                    update.UpdateId,
                    update.Type,
                    update.Serialize(writeIndented: false));

                try
                {
                    switch (update.Type)
                    {
                        case UpdateType.Message when update.Message is { } message:
                            await HandleMessageAsync(
                                api,
                                message,
                                config["TelegramBotApi:MiniAppUrl"] ?? DefaultMiniAppUrl,
                                logger,
                                cancellationToken);
                            break;

                        case UpdateType.CallbackQuery when update.CallbackQuery is { } callback:
                            await api.AnswerCallbackQueryAsync(
                                callback.Id,
                                text: $"Received: {callback.Data}",
                                cancellationToken: cancellationToken);
                            logger.LogInformation(
                                "Answered callback {CallbackId} from user {UserId} with data {CallbackData}",
                                callback.Id,
                                callback.From.Id,
                                callback.Data);
                            break;

                        case UpdateType.InlineQuery when update.InlineQuery is { } inlineQuery:
                            await api.AnswerInlineQueryAsync(
                                inlineQuery.Id,
                                [
                                    new InlineQueryResultArticle
                                    {
                                        Id = "event-harness-result",
                                        Title = "Telegram.BotAPI event probe",
                                        Description = "Select this result to complete the inline-query probe.",
                                        InputMessageContent = new InputTextMessageContent
                                        {
                                            MessageText = $"Inline query received: {inlineQuery.Query}"
                                        }
                                    }
                                ],
                                cacheTime: 0,
                                isPersonal: true,
                                cancellationToken: cancellationToken);
                            logger.LogInformation(
                                "Answered inline query {InlineQueryId} from user {UserId}",
                                inlineQuery.Id,
                                inlineQuery.From.Id);
                            break;

                        case UpdateType.ChatJoinRequest when update.ChatJoinRequest is { } joinRequest:
                            logger.LogWarning(
                                "Join request from user {UserId} for chat {ChatId}; query id: {QueryId}",
                                joinRequest.From.Id,
                                joinRequest.Chat.Id,
                                joinRequest.QueryId);
                            break;
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
            };

            await api.StartPollingAsync(
                limit: 10,
                maxParallel: 1,
                cancellationToken: cancellation.Token);
        }
        catch (OperationCanceledException) when (cancellation.IsCancellationRequested)
        {
            logger.LogInformation("Event harness stopped.");
        }
        catch (Exception exception)
        {
            logger.LogCritical(exception, "Event harness terminated unexpectedly.");
        }
    }

    private static async Task HandleMessageAsync(
        IBotApiClient api,
        Message message,
        string miniAppUrl,
        ILogger logger,
        CancellationToken cancellationToken)
    {
        if (message.WebAppData is { } webAppData)
        {
            logger.LogInformation(
                "Received Web App data from chat {ChatId}: button={ButtonText}, data={Data}",
                message.Chat.Id,
                webAppData.ButtonText,
                webAppData.Data);
            await api.SendMessageAsync(
                message.Chat.Id,
                "Web App data received.",
                replyMarkup: new ReplyKeyboardRemove { RemoveKeyboard = true },
                cancellationToken: cancellationToken);
            return;
        }

        var command = message.Text?
            .Split(' ', 2, StringSplitOptions.RemoveEmptyEntries)
            .FirstOrDefault()?
            .Split('@', 2)[0];

        if (command == "/probe")
        {
            await api.SendMessageAsync(
                message.Chat.Id,
                "Event harness: press the callback button, then launch the inline query.",
                replyMarkup: new InlineKeyboardMarkup
                {
                    InlineKeyboard =
                    [
                        [new InlineKeyboardButton
                        {
                            Text = "Callback query",
                            CallbackData = "event-harness:callback"
                        }],
                        [new InlineKeyboardButton
                        {
                            Text = "Inline query",
                            SwitchInlineQueryCurrentChat = "event-harness"
                        }]
                    ]
                },
                cancellationToken: cancellationToken);
            return;
        }

        if (command == "/webapp")
        {
            await api.SendMessageAsync(
                message.Chat.Id,
                "Open the Mini App and press Send test data.",
                replyMarkup: new ReplyKeyboardMarkup
                {
                    Keyboard =
                    [
                        [new KeyboardButton
                        {
                            Text = "Open event Mini App",
                            WebApp = new WebAppInfo { Url = miniAppUrl }
                        }]
                    ],
                    ResizeKeyboard = true,
                    OneTimeKeyboard = true
                },
                cancellationToken: cancellationToken);
        }
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
}
