using Endfix.Telegram.BotAPI.Extensions;
using Endfix.Telegram.BotAPI.Enums;
using Endfix.Telegram.BotAPI.Parameters;
using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;
using Xunit;

namespace Endfix.Telegram.BotAPI.Tests.Integration;

[Trait("Category", "Integration")]
[Collection(TelegramIntegrationCollection.Name)]
public sealed class TelegramFileIntegrationTests : IDisposable
{
    private static readonly byte[] PngBytes = Convert.FromBase64String(
        "iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAQAAAC1HAwCAAAAC0lEQVR42mNk+A8AAQUBAScY42YAAAAASUVORK5CYII=");

    private readonly HttpClient _httpClient = new();
    private readonly BotApiClient _client;
    private readonly long _chatId;

    public TelegramFileIntegrationTests()
    {
        var token = TelegramIntegrationSettings.Get(TelegramIntegrationFactAttribute.TokenVariable)
            ?? throw new InvalidOperationException("Telegram bot token is not configured.");
        _chatId = long.Parse(
            TelegramIntegrationSettings.Get(TelegramIntegrationFactAttribute.ChatIdVariable)
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
                Caption = "[Endfix.Telegram.BotAPI integration] sendPhoto: InputPhotoFile"
            });
            sentMessageIds.Add(upload.MessageId);

            var fileId = Assert.Single(upload.Photo!).FileId;
            var resend = await RequestAsync<Message>("sendPhoto", new SendPhotoParameters
            {
                ChatId = _chatId,
                Photo = fileId,
                Caption = "[Endfix.Telegram.BotAPI integration] sendPhoto: file_id"
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
            "Endfix.Telegram.BotAPI integration document"u8.ToArray());
        var sentMessageIds = new List<long>();

        try
        {
            var upload = await RequestAsync<Message>("sendDocument", new SendDocumentParameters
            {
                ChatId = _chatId,
                Document = new InputDocumentFile(file.Path),
                Caption = "[Endfix.Telegram.BotAPI integration] sendDocument: InputDocumentFile"
            });
            sentMessageIds.Add(upload.MessageId);

            var resend = await RequestAsync<Message>("sendDocument", new SendDocumentParameters
            {
                ChatId = _chatId,
                Document = upload.Document!.FileId,
                Caption = "[Endfix.Telegram.BotAPI integration] sendDocument: file_id"
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
                            Caption = "[Endfix.Telegram.BotAPI integration] sendMediaGroup: attach://attach_0"
                        },
                        new InputMediaPhoto
                        {
                            Media = new InputPhotoFile(secondFile.Path),
                            Caption = "[Endfix.Telegram.BotAPI integration] sendMediaGroup: attach://attach_1"
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
                Caption = "[Endfix.Telegram.BotAPI integration] sendPaidMedia: InputPhotoFile"
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
                Caption = "[Endfix.Telegram.BotAPI integration] sendPaidMedia: file_id"
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
    public async Task SendAdditionalStandaloneMedia_UploadsLocalFiles()
    {
        var sentMessageIds = new List<long>();

        try
        {
            var audio = await RequestAsync<Message>("sendAudio", new SendAudioParameters
            {
                ChatId = _chatId,
                Audio = new InputAudioFile(FixturePath("audio.mp3")),
                Thumbnail = new InputThumbnailFile(FixturePath("thumbnail.jpg")),
                Caption = "[Endfix.Telegram.BotAPI integration] sendAudio"
            });
            sentMessageIds.Add(audio.MessageId);
            Assert.NotNull(audio.Audio);

            var animation = await RequestAsync<Message>("sendAnimation", new SendAnimationParameters
            {
                ChatId = _chatId,
                Animation = new InputAnimationFile(FixturePath("animation.gif")),
                Thumbnail = new InputThumbnailFile(FixturePath("thumbnail.jpg")),
                Caption = "[Endfix.Telegram.BotAPI integration] sendAnimation"
            });
            sentMessageIds.Add(animation.MessageId);
            Assert.NotNull(animation.Animation);

            var video = await RequestAsync<Message>("sendVideo", new SendVideoParameters
            {
                ChatId = _chatId,
                Video = new InputVideoFile(FixturePath("video.mp4")),
                Thumbnail = new InputThumbnailFile(FixturePath("thumbnail.jpg")),
                Cover = new InputCoverFile(FixturePath("cover.jpg")),
                Caption = "[Endfix.Telegram.BotAPI integration] sendVideo"
            });
            sentMessageIds.Add(video.MessageId);
            Assert.NotNull(video.Video);

            var voice = await RequestAsync<Message>("sendVoice", new SendVoiceParameters
            {
                ChatId = _chatId,
                Voice = new InputVoiceFile(FixturePath("voice.ogg")),
                Caption = "[Endfix.Telegram.BotAPI integration] sendVoice"
            });
            sentMessageIds.Add(voice.MessageId);
            Assert.NotNull(voice.Voice);

            var videoNote = await RequestAsync<Message>("sendVideoNote", new SendVideoNoteParameters
            {
                ChatId = _chatId,
                VideoNote = new InputVideoNoteFile(FixturePath("video-note.mp4")),
                Thumbnail = new InputThumbnailFile(FixturePath("thumbnail.jpg"))
            });
            sentMessageIds.Add(videoNote.MessageId);
            Assert.NotNull(videoNote.VideoNote);

            var sticker = await RequestAsync<Message>("sendSticker", new SendStickerParameters
            {
                ChatId = _chatId,
                Sticker = new InputStickerFile(FixturePath("sticker-one.webp")),
                Emoji = "\u2600\uFE0F"
            });
            sentMessageIds.Add(sticker.MessageId);
            Assert.NotNull(sticker.Sticker);
        }
        finally
        {
            await DeleteMessagesAsync(sentMessageIds);
        }
    }

    [TelegramIntegrationFact]
    public async Task SendRichMessage_UploadsPhotoFromNestedBlock()
    {
        await using var file = await TemporaryFile.CreateAsync(".png", PngBytes);
        var sentMessageIds = new List<long>();

        try
        {
            var message = await _client.SendRichMessageAsync(
                chatId: _chatId,
                richMessage: new InputRichMessage
                {
                    Blocks =
                    [
                        new InputRichBlockParagraph
                        {
                            Text = new RichTextBold
                            {
                                Text = "Endfix.Telegram.BotAPI nested multipart test"
                            }
                        },
                        new InputRichBlockPhoto
                        {
                            Photo = new InputMediaPhoto
                            {
                                Media = new InputPhotoFile(file.Path)
                            },
                            Caption = new RichBlockCaption
                            {
                                Text = "InputRichBlockPhoto via attach://"
                            }
                        }
                    ]
                });

            sentMessageIds.Add(message.MessageId);
            Assert.NotNull(message.RichMessage);
        }
        finally
        {
            await DeleteMessagesAsync(sentMessageIds);
        }
    }

    [TelegramIntegrationFact]
    public async Task SetMyProfilePhoto_UploadsNestedPhoto_ThenRestoresPreviousPhoto()
    {
        var bot = await _client.GetMeAsync();
        var profilePhotos = await _client.GetUserProfilePhotosAsync(bot.Id, limit: 1);
        var previousPhoto = profilePhotos.Photos.FirstOrDefault()?.LastOrDefault();
        TemporaryFile? previousPhotoFile = null;

        if (previousPhoto is not null)
        {
            var file = await _client.GetFileAsync(previousPhoto.FileId);
            Assert.False(string.IsNullOrWhiteSpace(file.FilePath));
            previousPhotoFile = await TemporaryFile.CreateAsync(
                ".jpg",
                await _client.GetFileBytesAsync(file.FilePath!));
        }

        var profilePhotoSet = false;
        try
        {
            profilePhotoSet = await _client.SetMyProfilePhotoAsync(new InputProfilePhotoStatic
            {
                Photo = new InputPhotoFile(FixturePath("album-photo.jpg"))
            });

            Assert.True(profilePhotoSet);
        }
        finally
        {
            try
            {
                if (profilePhotoSet)
                {
                    Assert.True(await _client.RemoveMyProfilePhotoAsync());
                }
            }
            finally
            {
                if (previousPhotoFile is not null)
                {
                    try
                    {
                        Assert.True(await _client.SetMyProfilePhotoAsync(new InputProfilePhotoStatic
                        {
                            Photo = new InputPhotoFile(previousPhotoFile.Path)
                        }));
                    }
                    finally
                    {
                        await previousPhotoFile.DisposeAsync();
                    }
                }
            }
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
                Text = "[Endfix.Telegram.BotAPI integration] editMessageReplyMarkup",
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

    [TelegramIntegrationFact]
    public async Task SendMediaGroup_UploadsTypedVideoThumbnailAndCover()
    {
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
                            Media = new InputVideoFile(FixturePath("video.mp4")),
                            Thumbnail = new InputThumbnailFile(FixturePath("thumbnail.jpg")),
                            Cover = new InputCoverFile(FixturePath("cover.jpg")),
                            Caption = "[Endfix.Telegram.BotAPI integration] video: THUMBNAIL vs COVER"
                        },
                        new InputMediaPhoto
                        {
                            Media = new InputPhotoFile(FixturePath("album-photo.jpg")),
                            Caption = "[Endfix.Telegram.BotAPI integration] media group companion"
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

    [TelegramIntegrationFact]
    public async Task StickerSetMethods_UploadNestedFiles()
    {
        var bot = await _client.GetMeAsync();
        Assert.False(string.IsNullOrWhiteSpace(bot.Username));

        var setName = $"endfix_it_{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}_by_{bot.Username}"
            .ToLowerInvariant();
        var created = false;

        try
        {
            var uploaded = await _client.UploadStickerFileAsync(
                _chatId,
                new InputStickerFile(FixturePath("sticker-one.webp")),
                StickerFormat.Static);
            Assert.False(string.IsNullOrWhiteSpace(uploaded.FileId));

            created = await _client.CreateNewStickerSetAsync(
                _chatId,
                setName,
                "Endfix integration test",
                [CreateSticker("sticker-one.webp", "\u2600\uFE0F")]);
            Assert.True(created);

            var stickerSet = await _client.GetStickerSetAsync(setName);
            Assert.Single(stickerSet.Stickers);

            Assert.True(await _client.AddStickerToSetAsync(
                _chatId,
                setName,
                CreateSticker("sticker-two.webp", "\u26A1")));

            stickerSet = await _client.GetStickerSetAsync(setName);
            Assert.Equal(2, stickerSet.Stickers.Count);
            var replacedFileId = stickerSet.Stickers[0].FileId;

            Assert.True(await _client.ReplaceStickerInSetAsync(
                _chatId,
                setName,
                replacedFileId,
                CreateSticker("sticker-three.webp", "\u2705")));

            stickerSet = await _client.GetStickerSetAsync(setName);
            Assert.Equal(2, stickerSet.Stickers.Count);
            Assert.DoesNotContain(stickerSet.Stickers, sticker => sticker.FileId == replacedFileId);
        }
        finally
        {
            if (created)
            {
                Assert.True(await _client.DeleteStickerSetAsync(setName));
            }
        }
    }

    public void Dispose() => _httpClient.Dispose();

    private async Task<T> RequestAsync<T>(string methodName, ApiRequestParameters parameters)
    {
        var response = await _client.RequestAsync<T>(new ApiRequest(methodName, parameters));
        Assert.True(response.Ok, $"Telegram API {methodName} failed ({response.ErrorCode}): {response.Description}");
        return response.Result;
    }

    private static string FixturePath(string fileName)
    {
        var path = Path.Combine(AppContext.BaseDirectory, "Fixtures", "Media", fileName);
        Assert.True(File.Exists(path), $"Media fixture not found: {path}");
        return path;
    }

    private static InputSticker CreateSticker(string fileName, string emoji)
        => new()
        {
            Sticker = new InputStickerFile(FixturePath(fileName)),
            Format = InputStickerFormat.Static,
            EmojiList = [emoji]
        };

    private async Task DeleteMessagesAsync(IEnumerable<long> messageIds)
    {
        if (bool.TryParse(
            TelegramIntegrationSettings.Get(TelegramIntegrationFactAttribute.KeepMessagesVariable),
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
