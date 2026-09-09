using Endfix.Telegram.BotAPI.Enums;
using Endfix.Telegram.BotAPI.Exceptions;
using Endfix.Telegram.BotAPI.Extensions;
using Endfix.Telegram.BotAPI.Types;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Endfix.Telegram.BotAPI.Example.LongPolling;

internal class Program
{
    private const string DefaultMiniAppUrl = "https://endfix.github.io/telegram-bot-api/";
    private const string GroupIdSetting = "TELEGRAM_BOT_GROUP_ID";
    private const string OwnerChatIdSetting = "TELEGRAM_BOT_CHAT_ID";
    private const string TestUserIdSetting = "TELEGRAM_BOT_TEST_USER_ID";

    static async Task Main(string[] args)
    {
        var builder = Host.CreateApplicationBuilder(new HostApplicationBuilderSettings
        {
            Args = args,
            ContentRootPath = AppContext.BaseDirectory
        });
        builder.Configuration.AddUserSecrets<Program>(optional: true);
        builder.Logging.ClearProviders();
        builder.Logging
            .SetMinimumLevel(LogLevel.Debug)
            .AddSimpleConsole(options =>
            {
                options.SingleLine = true;
                options.TimestampFormat = "HH:mm:ss ";
            });

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
        builder.Services.AddSingleton<JoinRequestProbeState>();
        builder.Services.AddScoped<UpdateProcessor>();
        builder.Services.AddHostedService<TelegramPollingService>();

        await builder.Build().RunAsync();
    }

    private sealed class TelegramPollingService(
        IBotApiClient api,
        IServiceScopeFactory scopeFactory,
        ILogger<TelegramPollingService> logger) : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var bot = await api.GetMeAsync(stoppingToken);
            logger.LogInformation("Starting event harness for @{Username} ({BotId})", bot.Username, bot.Id);

            await api.DeleteWebhookAsync(dropPendingUpdates: false, cancellationToken: stoppingToken);
            logger.LogInformation(
                "Long polling is active. Send /probe, /webapp, or /join decline to @{Username}; press Ctrl+C to stop.",
                bot.Username);

            api.OnUpdate += HandleUpdateAsync;
            try
            {
                await api.StartPollingAsync(
                    limit: 10,
                    maxParallel: 1,
                    cancellationToken: stoppingToken);
            }
            finally
            {
                api.OnUpdate -= HandleUpdateAsync;
                logger.LogInformation("Event harness stopped.");
            }
        }

        private async Task HandleUpdateAsync(
            IBotApiClient sender,
            Update update,
            CancellationToken cancellationToken)
        {
            await using var scope = scopeFactory.CreateAsyncScope();
            var processor = scope.ServiceProvider.GetRequiredService<UpdateProcessor>();
            await processor.ProcessAsync(sender, update, cancellationToken);
        }
    }

    private sealed class UpdateProcessor(
        IConfiguration config,
        JoinRequestProbeState joinRequestProbe,
        ILogger<UpdateProcessor> logger)
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
                switch (update.Type)
                {
                    case UpdateType.Message when update.Message is { } message:
                        await HandleMessageAsync(
                            api,
                            message,
                            config["TelegramBotApi:MiniAppUrl"] ?? DefaultMiniAppUrl,
                            config,
                            joinRequestProbe,
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
                        await HandleJoinRequestAsync(
                            api,
                            joinRequest,
                            joinRequestProbe,
                            logger,
                            cancellationToken);
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
        }
    }

    private static async Task HandleMessageAsync(
        IBotApiClient api,
        Message message,
        string miniAppUrl,
        IConfiguration config,
        JoinRequestProbeState joinRequestProbe,
        ILogger logger,
        CancellationToken cancellationToken)
    {
        joinRequestProbe.RememberThread(message.Chat.Id, message.MessageThreadId);

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

        var commandParts = message.Text?
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var command = commandParts?
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
            return;
        }

        if (command == "/join")
        {
            await StartJoinRequestProbeAsync(
                api,
                message,
                commandParts,
                config,
                joinRequestProbe,
                logger,
                cancellationToken);
        }
    }

    private static async Task StartJoinRequestProbeAsync(
        IBotApiClient api,
        Message message,
        IReadOnlyList<string>? commandParts,
        IConfiguration config,
        JoinRequestProbeState state,
        ILogger logger,
        CancellationToken cancellationToken)
    {
        var ownerChatId = GetOptionalId(config, OwnerChatIdSetting, "TelegramBotApi:OwnerChatId");
        var groupId = GetOptionalId(config, GroupIdSetting, "TelegramBotApi:GroupId");
        var testUserId = GetOptionalId(config, TestUserIdSetting, "TelegramBotApi:TestUserId");
        if (ownerChatId is null || groupId is null)
        {
            await api.SendMessageAsync(
                message.Chat.Id,
                $"Configure {OwnerChatIdSetting} and {GroupIdSetting} before running the join-request probe.",
                messageThreadId: message.MessageThreadId,
                cancellationToken: cancellationToken);
            return;
        }

        var isAuthorized = message.Chat.Id == ownerChatId || message.Chat.Id == testUserId;
        if (message.Chat.Type != ChatTypes.Private || !isAuthorized)
        {
            logger.LogWarning("Ignored /join from unauthorized chat {ChatId}", message.Chat.Id);
            return;
        }

        var actionText = commandParts?.Skip(1).FirstOrDefault() ?? "decline";
        if (!Enum.TryParse<JoinRequestProbeAction>(actionText, ignoreCase: true, out var action))
        {
            await api.SendMessageAsync(
                message.Chat.Id,
                "Use /join decline or /join approve.",
                messageThreadId: message.MessageThreadId,
                cancellationToken: cancellationToken);
            return;
        }

        var probeUserId = testUserId ?? message.Chat.Id;
        var member = await api.GetChatMemberAsync(groupId.Value, probeUserId, cancellationToken);
        logger.LogInformation(
            "Join-request probe user {UserId} currently has status {MemberStatus} in chat {ChatId}",
            probeUserId,
            member.Status,
            groupId);
        if (member.Status == ChatMemberStatus.Kicked)
        {
            await api.UnbanChatMemberAsync(
                groupId.Value,
                probeUserId,
                onlyIfBanned: true,
                cancellationToken: cancellationToken);
            member = await api.GetChatMemberAsync(groupId.Value, probeUserId, cancellationToken);
            logger.LogInformation(
                "Unbanned join-request probe user {UserId}; current status: {MemberStatus}",
                probeUserId,
                member.Status);
        }

        if (member.Status != ChatMemberStatus.Left)
        {
            await api.SendMessageAsync(
                message.Chat.Id,
                $"The test user cannot submit a join request while its status is {member.Status}.",
                messageThreadId: message.MessageThreadId,
                cancellationToken: cancellationToken);
            return;
        }

        if (state.Current is { } previous)
        {
            await RevokeProbeLinkAsync(api, previous, logger, cancellationToken);
            state.Current = null;
        }

        var expiresAt = DateTimeOffset.UtcNow.AddMinutes(15);
        var requestedExpireDate = checked((int)expiresAt.ToUnixTimeSeconds());
        var inviteLink = await api.CreateChatInviteLinkAsync(
            groupId.Value,
            name: $"Event probe {action.ToString().ToLowerInvariant()}",
            expireDate: requestedExpireDate,
            createsJoinRequest: true,
            cancellationToken: cancellationToken);
        state.Current = new JoinRequestProbe(groupId.Value, inviteLink.InviteLink, action);

        var replyMarkup = new InlineKeyboardMarkup
        {
            InlineKeyboard =
            [
                [new InlineKeyboardButton
                {
                    Text = "Open join-request link",
                    Url = inviteLink.InviteLink
                }]
            ]
        };
        await api.SendMessageAsync(
            message.Chat.Id,
            $"Join-request probe created at {DateTimeOffset.Now:HH:mm:ss}. Open this link from an account that is not a member of the target group. The request will be {action.ToString().ToLowerInvariant()}d automatically.",
            messageThreadId: message.MessageThreadId,
            replyMarkup: replyMarkup,
            cancellationToken: cancellationToken);

        if (testUserId is not null && testUserId != message.Chat.Id)
        {
            try
            {
                await api.SendMessageAsync(
                    testUserId.Value,
                    $"Join-request probe created at {DateTimeOffset.Now:HH:mm:ss}: this request will be {action.ToString().ToLowerInvariant()}d automatically.",
                    messageThreadId: state.GetThread(testUserId.Value),
                    replyMarkup: replyMarkup,
                    cancellationToken: cancellationToken);
            }
            catch (ApiRequestException exception)
            {
                logger.LogWarning(
                    exception,
                    "Could not deliver the join-request link to test user {UserId}",
                    testUserId);
            }
        }

        logger.LogInformation(
            "Created a join-request link for chat {ChatId}; action: {Action}; test user: {TestUserId}; requested expiry: {RequestedExpireDate} ({ExpiresAt:u}); returned expiry: {ReturnedExpireDate}",
            groupId,
            action,
            testUserId,
            requestedExpireDate,
            expiresAt,
            inviteLink.ExpireDate);
    }

    private static async Task HandleJoinRequestAsync(
        IBotApiClient api,
        ChatJoinRequest joinRequest,
        JoinRequestProbeState state,
        ILogger logger,
        CancellationToken cancellationToken)
    {
        logger.LogWarning(
            "Join request from user {UserId} for chat {ChatId}; query id: {QueryId}",
            joinRequest.From.Id,
            joinRequest.Chat.Id,
            joinRequest.QueryId);

        if (state.Current is not { } probe ||
            probe.ChatId != joinRequest.Chat.Id ||
            joinRequest.InviteLink?.InviteLink != probe.InviteLink)
        {
            logger.LogWarning("The join request does not belong to the active probe and was left pending.");
            return;
        }

        if (!string.IsNullOrWhiteSpace(joinRequest.QueryId))
        {
            var result = probe.Action == JoinRequestProbeAction.Approve
                ? AnswerChatJoinRequestQueryResult.Approve
                : AnswerChatJoinRequestQueryResult.Decline;
            await api.AnswerChatJoinRequestQueryAsync(joinRequest.QueryId, result, cancellationToken);
        }
        else if (probe.Action == JoinRequestProbeAction.Approve)
        {
            await api.ApproveChatJoinRequestAsync(joinRequest.Chat.Id, joinRequest.From.Id, cancellationToken);
        }
        else
        {
            await api.DeclineChatJoinRequestAsync(joinRequest.Chat.Id, joinRequest.From.Id, cancellationToken);
        }

        logger.LogInformation(
            "Join request from user {UserId} was {Action}d successfully",
            joinRequest.From.Id,
            probe.Action.ToString().ToLowerInvariant());
        await RevokeProbeLinkAsync(api, probe, logger, cancellationToken);
        state.Current = null;
    }

    private static async Task RevokeProbeLinkAsync(
        IBotApiClient api,
        JoinRequestProbe probe,
        ILogger logger,
        CancellationToken cancellationToken)
    {
        try
        {
            await api.RevokeChatInviteLinkAsync(
                probe.ChatId,
                probe.InviteLink,
                cancellationToken);
        }
        catch (ApiRequestException exception)
        {
            logger.LogWarning(exception, "Could not revoke join-request probe link for chat {ChatId}", probe.ChatId);
        }
    }

    private static long? GetOptionalId(IConfiguration config, string environmentName, string configurationName)
    {
        var value = Environment.GetEnvironmentVariable(environmentName) ?? config[environmentName] ?? config[configurationName];
        return long.TryParse(value, out var id) ? id : null;
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

    private enum JoinRequestProbeAction
    {
        Approve,
        Decline
    }

    private sealed record JoinRequestProbe(long ChatId, string InviteLink, JoinRequestProbeAction Action);

    private sealed class JoinRequestProbeState
    {
        private readonly Dictionary<long, long?> _messageThreads = [];

        public JoinRequestProbe? Current { get; set; }

        public long? GetThread(long chatId)
            => _messageThreads.TryGetValue(chatId, out var messageThreadId) ? messageThreadId : null;

        public void RememberThread(long chatId, long? messageThreadId)
            => _messageThreads[chatId] = messageThreadId;
    }
}
