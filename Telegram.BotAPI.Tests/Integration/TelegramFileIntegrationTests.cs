using Telegram.BotAPI.Extensions;
using Telegram.BotAPI.Parameters;
using Telegram.BotAPI.Protocol;
using Telegram.BotAPI.Types;
using Xunit;

namespace Telegram.BotAPI.Tests.Integration;

[Trait("Category", "Integration")]
public sealed class TelegramFileIntegrationTests : IDisposable
{
    private static readonly byte[] PngBytes = Convert.FromBase64String(
        "iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAQAAAC1HAwCAAAAC0lEQVR42mNk+A8AAQUBAScY42YAAAAASUVORK5CYII=");

    private readonly HttpClient _httpClient = new();
    private readonly BotApiClient _client;
    private readonly long _chatId;

    public TelegramFileIntegrationTests()
    {
        var token = Environment.GetEnvironmentVariable(TelegramIntegrationFactAttribute.TokenVariable)
            ?? throw new InvalidOperationException("Telegram bot token is not configured.");
        _chatId = long.Parse(
            Environment.GetEnvironmentVariable(TelegramIntegrationFactAttribute.ChatIdVariable)
                ?? throw new InvalidOperationException("Telegram chat id is not configured."));
        _client = new BotApiClient(token, _httpClient);
    }

    [TelegramIntegrationFact]
    public async Task SendPhoto_UploadsLocalFile_ThenResendsByFileId()
    {
        await using var file = await TemporaryFile.CreateAsync(".png", PngBytes);
        var sentMessageIds = new List<long>();

        try
        {
            var upload = await RequestAsync<Message>("sendPhoto", new SendPhotoParameters
            {
                ChatId = _chatId,
                Photo = new InputPhotoFile(file.Path),
                Caption = "[Telegram.BotAPI integration] sendPhoto: InputPhotoFile"
            });
            sentMessageIds.Add(upload.MessageId);

            var fileId = Assert.Single(upload.Photo!).FileId;
            var resend = await RequestAsync<Message>("sendPhoto", new SendPhotoParameters
            {
                ChatId = _chatId,
                Photo = fileId,
                Caption = "[Telegram.BotAPI integration] sendPhoto: file_id"
            });
            sentMessageIds.Add(resend.MessageId);
        }
        finally
        {
            await DeleteMessagesAsync(sentMessageIds);
        }
    }

    [TelegramIntegrationFact]
    public async Task SendDocument_UploadsLocalFile_ThenResendsByFileId()
    {
        await using var file = await TemporaryFile.CreateAsync(
            ".txt",
            "Telegram.BotAPI integration document"u8.ToArray());
        var sentMessageIds = new List<long>();

        try
        {
            var upload = await RequestAsync<Message>("sendDocument", new SendDocumentParameters
            {
                ChatId = _chatId,
                Document = new InputDocumentFile(file.Path),
                Caption = "[Telegram.BotAPI integration] sendDocument: InputDocumentFile"
            });
            sentMessageIds.Add(upload.MessageId);

            var resend = await RequestAsync<Message>("sendDocument", new SendDocumentParameters
            {
                ChatId = _chatId,
                Document = upload.Document!.FileId,
                Caption = "[Telegram.BotAPI integration] sendDocument: file_id"
            });
            sentMessageIds.Add(resend.MessageId);
        }
        finally
        {
            await DeleteMessagesAsync(sentMessageIds);
        }
    }

    [TelegramIntegrationFact]
    public async Task SendMediaGroup_UploadsFilesThroughAttachReferences()
    {
        await using var firstFile = await TemporaryFile.CreateAsync(".png", PngBytes);
        await using var secondFile = await TemporaryFile.CreateAsync(".png", PngBytes);
        var sentMessageIds = new List<long>();

        try
        {
            var messages = await RequestAsync<IReadOnlyList<Message>>(
                "sendMediaGroup",
                new SendMediaGroupParameters
                {
                    ChatId = _chatId,
                    Media =
                    [
                        new InputMediaPhoto
                        {
                            Media = new InputPhotoFile(firstFile.Path),
                            Caption = "[Telegram.BotAPI integration] sendMediaGroup: attach://attach_0"
                        },
                        new InputMediaPhoto
                        {
                            Media = new InputPhotoFile(secondFile.Path),
                            Caption = "[Telegram.BotAPI integration] sendMediaGroup: attach://attach_1"
                        }
                    ]
                });

            messages.ShouldHaveCount(2);
            sentMessageIds.AddRange(messages.Select(message => message.MessageId));
        }
        finally
        {
            await DeleteMessagesAsync(sentMessageIds);
        }
    }

    [TelegramIntegrationFact]
    public async Task SendPaidMedia_UploadsLocalPhoto_ThenResendsByFileId()
    {
        await using var file = await TemporaryFile.CreateAsync(".png", PngBytes);
        var sentMessageIds = new List<long>();

        try
        {
            var upload = await RequestAsync<Message>("sendPaidMedia", new SendPaidMediaParameters
            {
                ChatId = _chatId,
                StarCount = 1,
                Media =
                [
                    new InputPaidMediaPhoto
                    {
                        Media = new InputPhotoFile(file.Path)
                    }
                ],
                Caption = "[Telegram.BotAPI integration] sendPaidMedia: InputPhotoFile"
            });
            sentMessageIds.Add(upload.MessageId);

            Assert.NotNull(upload.PaidMedia);
            Assert.Equal(1, upload.PaidMedia.StarCount);
            var paidPhoto = Assert.IsType<PaidMediaPhoto>(Assert.Single(upload.PaidMedia.PaidMedia));
            var fileId = paidPhoto.Photo[^1].FileId;

            var resend = await RequestAsync<Message>("sendPaidMedia", new SendPaidMediaParameters
            {
                ChatId = _chatId,
                StarCount = 1,
                Media =
                [
                    new InputPaidMediaPhoto
                    {
                        Media = fileId
                    }
                ],
                Caption = "[Telegram.BotAPI integration] sendPaidMedia: file_id"
            });
            sentMessageIds.Add(resend.MessageId);

            Assert.NotNull(resend.PaidMedia);
            Assert.Equal(1, resend.PaidMedia.StarCount);
            Assert.IsType<PaidMediaPhoto>(Assert.Single(resend.PaidMedia.PaidMedia));
        }
        finally
        {
            await DeleteMessagesAsync(sentMessageIds);
        }
    }

    [TelegramIntegrationFact]
    public async Task UpdatingMethods_ForwardChatAndReplyMarkupParameters()
    {
        var sentMessageIds = new List<long>();

        try
        {
            var message = await RequestAsync<Message>("sendMessage", new SendMessageParameters
            {
                ChatId = _chatId,
                Text = "[Telegram.BotAPI integration] editMessageReplyMarkup",
                ReplyMarkup = new InlineKeyboardMarkup
                {
                    InlineKeyboard =
                    [
                        [new InlineKeyboardButton { Text = "Before", CallbackData = "before" }]
                    ]
                }
            });
            sentMessageIds.Add(message.MessageId);

            var edited = await _client.EditMessageReplyMarkupAsync(
                chatId: _chatId,
                messageId: message.MessageId,
                replyMarkup: new InlineKeyboardMarkup
                {
                    InlineKeyboard =
                    [
                        [new InlineKeyboardButton { Text = "After", CallbackData = "after" }]
                    ]
                });

            Assert.Equal("after", edited.ReplyMarkup!.InlineKeyboard[0][0].CallbackData);

            var location = await RequestAsync<Message>("sendLocation", new SendLocationParameters
            {
                ChatId = _chatId,
                Latitude = 55.751244,
                Longitude = 37.618423,
                LivePeriod = 60
            });
            sentMessageIds.Add(location.MessageId);

            var stopped = await _client.StopMessageLiveLocationAsync(
                chatId: _chatId,
                messageId: location.MessageId);

            Assert.Equal(location.MessageId, stopped.MessageId);
        }
        finally
        {
            await DeleteMessagesAsync(sentMessageIds);
        }
    }

    [TelegramMediaIntegrationFact]
    public async Task SendMediaGroup_UploadsTypedVideoThumbnailAndCover()
    {
        var videoPath = Environment.GetEnvironmentVariable(TelegramIntegrationFactAttribute.VideoPathVariable)!;
        var imagePath = Environment.GetEnvironmentVariable(TelegramIntegrationFactAttribute.ImagePathVariable)!;
        var thumbnailPath = Environment.GetEnvironmentVariable(TelegramIntegrationFactAttribute.ThumbnailPathVariable)!;
        var coverPath = Environment.GetEnvironmentVariable(TelegramIntegrationFactAttribute.CoverPathVariable)!;
        var sentMessageIds = new List<long>();

        try
        {
            var messages = await RequestAsync<IReadOnlyList<Message>>(
                "sendMediaGroup",
                new SendMediaGroupParameters
                {
                    ChatId = _chatId,
                    Media =
                    [
                        new InputMediaVideo
                        {
                            Media = new InputVideoFile(videoPath),
                            Thumbnail = new InputThumbnailFile(thumbnailPath),
                            Cover = new InputCoverFile(coverPath),
                            Caption = "[Telegram.BotAPI integration] video: THUMBNAIL vs COVER"
                        },
                        new InputMediaPhoto
                        {
                            Media = new InputPhotoFile(imagePath),
                            Caption = "[Telegram.BotAPI integration] media group companion"
                        }
                    ]
                });

            Assert.Equal(2, messages.Count);
            Assert.NotNull(messages[0].Video);
            sentMessageIds.AddRange(messages.Select(message => message.MessageId));
        }
        finally
        {
            await DeleteMessagesAsync(sentMessageIds);
        }
    }

    public void Dispose() => _httpClient.Dispose();

    private async Task<T> RequestAsync<T>(string methodName, ApiRequestParameters parameters)
    {
        var response = await _client.RequestAsync<T>(new ApiRequest(methodName, parameters));
        Assert.True(response.Ok, $"Telegram API {methodName} failed ({response.ErrorCode}): {response.Description}");
        return response.Result;
    }

    private async Task DeleteMessagesAsync(IEnumerable<long> messageIds)
    {
        if (bool.TryParse(
            Environment.GetEnvironmentVariable(TelegramIntegrationFactAttribute.KeepMessagesVariable),
            out var keepMessages) && keepMessages)
        {
            return;
        }

        foreach (var messageId in messageIds)
        {
            await _client.RequestAsync<bool>(new ApiRequest("deleteMessage", new DeleteMessageParameters
            {
                ChatId = _chatId,
                MessageId = messageId
            }));
        }
    }

    private sealed class TemporaryFile(string path) : IAsyncDisposable
    {
        public string Path => path;

        public static async Task<TemporaryFile> CreateAsync(string extension, byte[] content)
        {
            var path = System.IO.Path.Combine(
                System.IO.Path.GetTempPath(),
                $"telegram-botapi-{Guid.NewGuid():N}{extension}");

            await File.WriteAllBytesAsync(path, content);
            return new TemporaryFile(path);
        }

        public ValueTask DisposeAsync()
        {
            File.Delete(path);
            return ValueTask.CompletedTask;
        }
    }
}

internal static class IntegrationAssertions
{
    public static void ShouldHaveCount<T>(this IReadOnlyCollection<T> items, int expected)
        => Assert.Equal(expected, items.Count);
}
