using Endfix.Telegram.BotAPI;
using Endfix.Telegram.BotAPI.Enums;
using Endfix.Telegram.BotAPI.Extensions;
using Endfix.Telegram.BotAPI.Types;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Endfix.Telegram.BotAPI.Tests.Integration;

[Trait("Category", "Integration")]
[Collection(TelegramIntegrationCollection.Name)]
public sealed class TelegramInlineIntegrationTests : IDisposable
{
    private readonly HttpClient _httpClient = TelegramIntegrationHttp.CreateClient();
    private readonly BotApiClient _client;
    private readonly long _chatId;
    private readonly ITestOutputHelper _output;

    public TelegramInlineIntegrationTests(ITestOutputHelper output)
    {
        _output = output;
        var token = TelegramIntegrationSettings.Get(TelegramIntegrationFactAttribute.TokenVariable)
            ?? throw new InvalidOperationException("Telegram bot token is not configured.");
        _chatId = long.Parse(
            TelegramIntegrationSettings.Get(TelegramIntegrationFactAttribute.ChatIdVariable)
                ?? throw new InvalidOperationException("Telegram chat id is not configured."));
        _client = new BotApiClient(token, _httpClient, maxRetryAttempts: 0);
    }

    [TelegramIntegrationFact]
    public async Task InlineMessageEdits_ReturnTrue()
    {
        var bot = await _client.GetMeAsync();
        await _client.DeleteWebhookAsync(dropPendingUpdates: true);

        using var timeout = new CancellationTokenSource(TimeSpan.FromMinutes(3));
        var inlineMessageId = new TaskCompletionSource<string>(
            TaskCreationOptions.RunContinuationsAsynchronously);

        _client.OnUpdate += async (_, update, cancellationToken) =>
        {
            if (update.Message is { Text: { } text, Chat.Id: var chatId } &&
                chatId == _chatId &&
                (text == "/start" || text.StartsWith("/start@", StringComparison.Ordinal)))
            {
                await SendPromptAsync(bot.Username!, cancellationToken);
                return;
            }

            if (update.InlineQuery is { } inlineQuery)
            {
                await _client.AnswerInlineQueryAsync(
                    inlineQuery.Id,
                    [
                        new InlineQueryResultArticle
                        {
                            Id = "endfix-inline-edit",
                            Title = "Endfix inline edit",
                            Description = "Select this result to finish the live test.",
                            InputMessageContent = new InputTextMessageContent
                            {
                                MessageText = "Endfix inline: before edit"
                            },
                            ReplyMarkup = new InlineKeyboardMarkup
                            {
                                InlineKeyboard =
                                [
                                    [new InlineKeyboardButton { Text = "Before", CallbackData = "before" }]
                                ]
                            }
                        }
                    ],
                    cacheTime: 0,
                    isPersonal: true,
                    cancellationToken: cancellationToken);
                return;
            }

            if (update.ChosenInlineResult?.InlineMessageId is { Length: > 0 } chosenId)
            {
                inlineMessageId.TrySetResult(chosenId);
            }
        };

        var polling = _client.StartPollingAsync(
            limit: 10,
            timeout: 20,
            allowedUpdates:
            [
                UpdateType.Message,
                UpdateType.InlineQuery,
                UpdateType.ChosenInlineResult
            ],
            cancellationToken: timeout.Token);

        await SendPromptAsync(bot.Username!, timeout.Token);
        _output.WriteLine("Sent the inline prompt to the private chat. Tap the button, then select the result.");

        string capturedId;
        try
        {
            capturedId = await inlineMessageId.Task.WaitAsync(timeout.Token);
        }
        catch (OperationCanceledException)
        {
            throw SkipException.ForSkip(
                "No inline result was chosen within 3 minutes. Open the private chat with the bot, tap the button, and select the result.");
        }
        finally
        {
            timeout.Cancel();
            try
            {
                await polling;
            }
            catch (OperationCanceledException)
            {
            }

            await _client.GetUpdatesAsync(
                limit: 1,
                timeout: 0,
                AllowedUpdates: []);
        }

        Assert.True(await _client.EditMessageTextForInlineMessageAsync(
            capturedId,
            "Endfix inline: after edit"));
        Assert.True(await _client.EditMessageReplyMarkupForInlineMessageAsync(
            capturedId,
            new InlineKeyboardMarkup
            {
                InlineKeyboard =
                [
                    [new InlineKeyboardButton { Text = "After", CallbackData = "after" }]
                ]
            }));
    }

    private Task<Message> SendPromptAsync(string username, CancellationToken cancellationToken)
        => _client.SendMessageAsync(
            _chatId,
            $"Live inline test is running. Tap the button and select the @{username} result.",
            replyMarkup: new InlineKeyboardMarkup
            {
                InlineKeyboard =
                [
                    [
                        new InlineKeyboardButton
                        {
                            Text = "Choose inline result",
                            SwitchInlineQueryCurrentChat = "endfix"
                        }
                    ]
                ]
            },
            cancellationToken: cancellationToken);

    public void Dispose()
    {
        _client.Dispose();
        _httpClient.Dispose();
    }
}
