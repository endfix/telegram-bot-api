using FluentAssertions;
using System.Text.Json;
using Endfix.Telegram.BotAPI.Parameters;
using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Tests.Infrastructure;
using Endfix.Telegram.BotAPI.Types;
using Xunit;

namespace Endfix.Telegram.BotAPI.Tests;

public sealed class TransportSerializationTests
{
    [Fact]
    public async Task SendPhoto_WithFileId_SendsPlainSourceValue()
    {
        using var context = new ClientContext();

        await context.Client.RequestAsync<bool>(new ApiRequest("sendPhoto", new SendPhotoParameters
        {
            ChatId = 123456789L,
            Photo = "photo-file-id"
        }));

        context.Handler.LastRequest.Should().NotBeNull();
        var request = context.Handler.LastRequest!;
        var photo = request.Parts.Should().ContainSingle(part => part.Name == "photo").Which;
        Assert.Equal("photo-file-id", photo.Text);
    }

    [Fact]
    public async Task SendPhoto_WithLocalFile_SendsBinaryPart()
    {
        var file = await TemporaryFile.CreateAsync([0x01, 0x02, 0x03, 0xFF]);
        await using var _ = file;
        using var context = new ClientContext();

        await context.Client.RequestAsync<bool>(new ApiRequest("sendPhoto", new SendPhotoParameters
        {
            ChatId = 123456789L,
            Photo = new InputPhotoFile(file.Path)
        }));

        context.Handler.LastRequest.Should().NotBeNull();
        var request = context.Handler.LastRequest!;
        var photo = request.Parts.Should().ContainSingle(part => part.Name == "photo").Which;
        photo.FileName.Should().Be(System.IO.Path.GetFileName(file.Path));
        photo.Content.Should().Equal(0x01, 0x02, 0x03, 0xFF);
    }

    [Fact]
    public async Task SendPhoto_WithMemorySource_SendsSnapshotWithoutOpeningAFile()
    {
        var content = new byte[] { 0x11, 0x22, 0x33 };
        var source = InputFileSource.FromMemory(content, "memory-photo.jpg");
        content[0] = 0xFF;
        using var context = new ClientContext();

        await context.Client.RequestAsync<bool>(new ApiRequest("sendPhoto", new SendPhotoParameters
        {
            ChatId = 123456789L,
            Photo = new InputPhotoFile(source)
        }));

        var photo = context.Handler.LastRequest!.Parts
            .Should().ContainSingle(part => part.Name == "photo").Which;
        photo.FileName.Should().Be("memory-photo.jpg");
        photo.Content.Should().Equal(0x11, 0x22, 0x33);
    }

    [Fact]
    public async Task SendMediaGroup_WithStreamFactory_ReopensAndDisposesStreamForRetry()
    {
        var streamsCreated = 0;
        var streamsDisposed = 0;
        var source = InputFileSource.FromStream(
            () =>
            {
                streamsCreated++;
                return new TrackingMemoryStream(
                    new byte[] { 0x41, 0x42, 0x43 },
                    () => streamsDisposed++);
            },
            "factory-photo.jpg");
        using var handler = new RetryRecordingHandler();
        using var httpClient = new HttpClient(handler);
        using var client = new BotApiClient("test-token", httpClient, maxRetryAttempts: 1);

        var response = await client.RequestAsync<bool>(new ApiRequest("sendMediaGroup", new SendMediaGroupParameters
        {
            ChatId = 123456789L,
            Media =
            [
                new InputMediaPhoto
                {
                    Media = new InputPhotoFile(source)
                }
            ]
        }));

        response.Ok.Should().BeTrue();
        handler.Attachments.Should().HaveCount(2)
            .And.OnlyContain(content => content.SequenceEqual(new byte[] { 0x41, 0x42, 0x43 }));
        streamsCreated.Should().Be(2);
        streamsDisposed.Should().Be(2);
    }

    [Fact]
    public async Task SendMediaGroup_WithLocalFile_SendsAttachReferenceAndBinaryPart()
    {
        var file = await TemporaryFile.CreateAsync([0x10, 0x20, 0x30]);
        await using var _ = file;
        using var context = new ClientContext();

        await context.Client.RequestAsync<bool>(new ApiRequest("sendMediaGroup", new SendMediaGroupParameters
        {
            ChatId = 123456789L,
            Media =
            [
                new InputMediaPhoto
                {
                    Media = new InputPhotoFile(file.Path),
                    Caption = "Photo"
                }
            ]
        }));

        context.Handler.LastRequest.Should().NotBeNull();
        var request = context.Handler.LastRequest!;
        request.Parts.Should().ContainSingle(part => part.Name == "attach_0")
            .Which.Content.Should().Equal(0x10, 0x20, 0x30);
        request.Parts.Should().ContainSingle(part => part.Name == "media")
            .Which.Text.Should().Contain("\"media\":\"attach://attach_0\"");
    }

    [Fact]
    public async Task SendMediaGroup_WithLivePhoto_SendsBothFileAttachments()
    {
        var videoFile = await TemporaryFile.CreateAsync([0x11, 0x12]);
        await using var _ = videoFile;
        var photoFile = await TemporaryFile.CreateAsync([0x21, 0x22]);
        await using var __ = photoFile;
        using var context = new ClientContext();

        await context.Client.RequestAsync<bool>(new ApiRequest("sendMediaGroup", new SendMediaGroupParameters
        {
            ChatId = 123456789L,
            Media =
            [
                new InputMediaLivePhoto
                {
                    Media = new InputVideoFile(videoFile.Path),
                    Photo = new InputPhotoFile(photoFile.Path)
                }
            ]
        }));

        context.Handler.LastRequest.Should().NotBeNull();
        var request = context.Handler.LastRequest!;
        request.Parts.Should().ContainSingle(part => part.Name == "attach_0")
            .Which.Content.Should().Equal(0x11, 0x12);
        request.Parts.Should().ContainSingle(part => part.Name == "attach_1")
            .Which.Content.Should().Equal(0x21, 0x22);

        var media = request.Parts.Should().ContainSingle(part => part.Name == "media").Which.Text;
        media.Should().Contain("\"media\":\"attach://attach_0\"");
        media.Should().Contain("\"photo\":\"attach://attach_1\"");
    }

    [Fact]
    public async Task SendPoll_WithNestedLocalFiles_SendsAttachReferencesAndBinaryParts()
    {
        var optionFile = await TemporaryFile.CreateAsync([0x31, 0x32]);
        await using var _ = optionFile;
        var pollFile = await TemporaryFile.CreateAsync([0x41, 0x42]);
        await using var __ = pollFile;
        using var context = new ClientContext();

        await context.Client.RequestAsync<bool>(new ApiRequest("sendPoll", new SendPollParameters
        {
            ChatId = 123456789L,
            Question = "Question",
            Options =
            [
                new InputPollOption
                {
                    Text = "Option",
                    Media = new InputMediaPhoto
                    {
                        Media = new InputPhotoFile(optionFile.Path)
                    }
                }
            ],
            Media = new InputMediaPhoto
            {
                Media = new InputPhotoFile(pollFile.Path)
            }
        }));

        context.Handler.LastRequest.Should().NotBeNull();
        var request = context.Handler.LastRequest!;
        request.Parts.Should().ContainSingle(part => part.Name == "attach_0")
            .Which.Content.Should().Equal(0x31, 0x32);
        request.Parts.Should().ContainSingle(part => part.Name == "attach_1")
            .Which.Content.Should().Equal(0x41, 0x42);

        using var options = JsonDocument.Parse(
            request.Parts.Should().ContainSingle(part => part.Name == "options").Which.Text);
        options.RootElement[0].GetProperty("media").GetProperty("media")
            .GetString().Should().Be("attach://attach_0");

        using var media = JsonDocument.Parse(
            request.Parts.Should().ContainSingle(part => part.Name == "media").Which.Text);
        media.RootElement.GetProperty("media")
            .GetString().Should().Be("attach://attach_1");
    }

    [Fact]
    public async Task SendMediaGroup_WithVideo_SendsThumbnailAndCoverAttachments()
    {
        var videoFile = await TemporaryFile.CreateAsync([0x31]);
        await using var _ = videoFile;
        var thumbnailFile = await TemporaryFile.CreateAsync([0x32]);
        await using var __ = thumbnailFile;
        var coverFile = await TemporaryFile.CreateAsync([0x33]);
        await using var ___ = coverFile;
        using var context = new ClientContext();

        await context.Client.RequestAsync<bool>(new ApiRequest("sendMediaGroup", new SendMediaGroupParameters
        {
            ChatId = 123456789L,
            Media =
            [
                new InputMediaVideo
                {
                    Media = new InputVideoFile(videoFile.Path),
                    Thumbnail = new InputThumbnailFile(thumbnailFile.Path),
                    Cover = new InputCoverFile(coverFile.Path)
                }
            ]
        }));

        context.Handler.LastRequest.Should().NotBeNull();
        var request = context.Handler.LastRequest!;
        request.Parts.Should().ContainSingle(part => part.Name == "attach_0")
            .Which.Content.Should().Equal(0x31);
        request.Parts.Should().ContainSingle(part => part.Name == "attach_1")
            .Which.Content.Should().Equal(0x32);
        request.Parts.Should().ContainSingle(part => part.Name == "attach_2")
            .Which.Content.Should().Equal(0x33);

        var media = request.Parts.Should().ContainSingle(part => part.Name == "media").Which.Text;
        media.Should().Contain("\"media\":\"attach://attach_0\"");
        media.Should().Contain("\"thumbnail\":\"attach://attach_1\"");
        media.Should().Contain("\"cover\":\"attach://attach_2\"");
    }

    [Fact]
    public async Task EditEphemeralMessageMedia_WithLocalVideo_SendsObjectAndNestedAttachments()
    {
        var videoFile = await TemporaryFile.CreateAsync([0x41]);
        await using var _ = videoFile;
        var thumbnailFile = await TemporaryFile.CreateAsync([0x42]);
        await using var __ = thumbnailFile;
        var coverFile = await TemporaryFile.CreateAsync([0x43]);
        await using var ___ = coverFile;
        using var context = new ClientContext();

        await context.Client.RequestAsync<bool>(new ApiRequest(
            "editEphemeralMessageMedia",
            new EditEphemeralMessageMediaParameters
            {
                ChatId = 123456789L,
                ReceiverUserId = 987654321L,
                EphemeralMessageId = 12,
                Media = new InputMediaVideo
                {
                    Media = new InputVideoFile(videoFile.Path),
                    Thumbnail = new InputThumbnailFile(thumbnailFile.Path),
                    Cover = new InputCoverFile(coverFile.Path)
                }
            }));

        context.Handler.LastRequest.Should().NotBeNull();
        var request = context.Handler.LastRequest!;
        for (var index = 0; index < 3; index++)
        {
            request.Parts.Should().ContainSingle(part => part.Name == $"attach_{index}")
                .Which.Content.Should().Equal((byte)(0x41 + index));
        }

        var mediaJson = request.Parts.Should().ContainSingle(part => part.Name == "media").Which.Text;
        using var document = JsonDocument.Parse(mediaJson);
        var media = document.RootElement;

        media.ValueKind.Should().Be(JsonValueKind.Object);
        media.GetProperty("media").GetString().Should().Be("attach://attach_0");
        media.GetProperty("thumbnail").GetString().Should().Be("attach://attach_1");
        media.GetProperty("cover").GetString().Should().Be("attach://attach_2");
    }

    [Fact]
    public async Task SendMessage_PreservesConcreteReplyMarkupFields()
    {
        using var context = new ClientContext();

        await context.Client.RequestAsync<bool>(new ApiRequest("sendMessage", new SendMessageParameters
        {
            ChatId = "@contract_test",
            Text = "Choose",
            ReplyMarkup = new InlineKeyboardMarkup
            {
                InlineKeyboard =
                [
                    [new InlineKeyboardButton { Text = "Open", CallbackData = "open" }]
                ]
            }
        }));

        context.Handler.LastRequest.Should().NotBeNull();
        var request = context.Handler.LastRequest!;
        request.Parts.Should().ContainSingle(part => part.Name == "chat_id")
            .Which.Text.Should().Be("@contract_test");
        var replyMarkup = request.Parts.Should()
            .ContainSingle(part => part.Name == "reply_markup")
            .Which.Text;

        replyMarkup.Should().Contain("\"inline_keyboard\"");
        replyMarkup.Should().Contain("\"callback_data\":\"open\"");
    }

    [Fact]
    public async Task SendMessage_SerializesScalarMultipartFieldsWithoutJsonQuotes()
    {
        using var context = new ClientContext();

        await context.Client.RequestAsync<bool>(new ApiRequest("sendMessage", new SendMessageParameters
        {
            ChatId = 123456789L,
            MessageThreadId = 42,
            Text = "Scalars",
            DisableNotification = true
        }));

        context.Handler.LastRequest.Should().NotBeNull();
        var parts = context.Handler.LastRequest!.Parts;
        parts.Should().ContainSingle(part => part.Name == "chat_id")
            .Which.Text.Should().Be("123456789");
        parts.Should().ContainSingle(part => part.Name == "message_thread_id")
            .Which.Text.Should().Be("42");
        parts.Should().ContainSingle(part => part.Name == "disable_notification")
            .Which.Text.Should().Be("true");
    }

    [Fact]
    public async Task SetWebhook_WithCertificate_UsesUnquotedMultipartFieldName()
    {
        var file = await TemporaryFile.CreateAsync([0xCA, 0xFE]);
        await using var _ = file;
        using var context = new ClientContext();

        await context.Client.RequestAsync<bool>(new ApiRequest("setWebhook", new SetWebhookParameters
        {
            Url = "https://example.com/telegram/webhook",
            Certificate = new InputCertificateFile(file.Path)
        }));

        context.Handler.LastRequest.Should().NotBeNull();
        var request = context.Handler.LastRequest!;
        request.Parts.Should().ContainSingle(part => part.Name == "certificate")
            .Which.Content.Should().Equal(0xCA, 0xFE);
    }

    [Fact]
    public async Task SendLivePhoto_UsesParameterNamesForBothFileParts()
    {
        var videoFile = await TemporaryFile.CreateAsync([0x01, 0x02]);
        await using var _ = videoFile;
        var photoFile = await TemporaryFile.CreateAsync([0x03, 0x04]);
        await using var __ = photoFile;
        using var context = new ClientContext();

        await context.Client.RequestAsync<bool>(new ApiRequest("sendLivePhoto", new SendLivePhotoParameters
        {
            ChatId = 123456789L,
            LivePhoto = new InputVideoFile(videoFile.Path),
            Photo = new InputPhotoFile(photoFile.Path)
        }));

        context.Handler.LastRequest.Should().NotBeNull();
        context.Handler.LastRequest!.Parts.Should().ContainSingle(part => part.Name == "live_photo")
            .Which.Content.Should().Equal(0x01, 0x02);
        context.Handler.LastRequest.Parts.Should().ContainSingle(part => part.Name == "photo")
            .Which.Content.Should().Equal(0x03, 0x04);
    }

    [Fact]
    public async Task SendPaidMedia_WithLocalFiles_SendsAllNestedAttachments()
    {
        var files = new List<TemporaryFile>();
        for (byte value = 0x41; value <= 0x46; value++)
        {
            files.Add(await TemporaryFile.CreateAsync([value]));
        }

        try
        {
            using var context = new ClientContext();

            await context.Client.RequestAsync<bool>(new ApiRequest("sendPaidMedia", new SendPaidMediaParameters
            {
                ChatId = 123456789L,
                StarCount = 1,
                Media =
                [
                    new InputPaidMediaPhoto
                    {
                        Media = new InputPhotoFile(files[0].Path)
                    },
                    new InputPaidMediaLivePhoto
                    {
                        Media = new InputVideoFile(files[1].Path),
                        Photo = new InputPhotoFile(files[2].Path)
                    },
                    new InputPaidMediaVideo
                    {
                        Media = new InputVideoFile(files[3].Path),
                        Thumbnail = new InputThumbnailFile(files[4].Path),
                        Cover = new InputCoverFile(files[5].Path)
                    }
                ]
            }));

            context.Handler.LastRequest.Should().NotBeNull();
            var request = context.Handler.LastRequest!;
            for (var index = 0; index < files.Count; index++)
            {
                request.Parts.Should().ContainSingle(part => part.Name == $"attach_{index}")
                    .Which.Content.Should().Equal((byte)(0x41 + index));
            }

            var mediaJson = request.Parts.Should().ContainSingle(part => part.Name == "media").Which.Text;
            using var document = JsonDocument.Parse(mediaJson);
            var media = document.RootElement;

            media[0].GetProperty("media").GetString().Should().Be("attach://attach_0");
            media[1].GetProperty("media").GetString().Should().Be("attach://attach_1");
            media[1].GetProperty("photo").GetString().Should().Be("attach://attach_2");
            media[2].GetProperty("media").GetString().Should().Be("attach://attach_3");
            media[2].GetProperty("thumbnail").GetString().Should().Be("attach://attach_4");
            media[2].GetProperty("cover").GetString().Should().Be("attach://attach_5");
        }
        finally
        {
            foreach (var file in files)
            {
                await file.DisposeAsync();
            }
        }
    }

    [Fact]
    public async Task SendPoll_SendsTopLevelEnumWithoutJsonQuotes()
    {
        using var context = new ClientContext();

        await context.Client.RequestAsync<bool>(new ApiRequest("sendPoll", new SendPollParameters
        {
            ChatId = 123456789L,
            Question = "Choose",
            Options = [new InputPollOption { Text = "One" }],
            Type = Endfix.Telegram.BotAPI.Enums.PollType.Quiz
        }));

        context.Handler.LastRequest.Should().NotBeNull();
        context.Handler.LastRequest!.Parts.Should().ContainSingle(part => part.Name == "type")
            .Which.Text.Should().Be("quiz");
    }

    [Fact]
    public async Task PostStory_WithLocalPhoto_AttachesNestedFile()
    {
        var file = await TemporaryFile.CreateAsync([0x51, 0x52]);
        await using var _ = file;
        using var context = new ClientContext();

        await context.Client.RequestAsync<bool>(new ApiRequest("postStory", new PostStoryParameters
        {
            BusinessConnectionId = "business-connection",
            Content = new InputStoryContentPhoto
            {
                Photo = new InputPhotoFile(file.Path)
            },
            ActivePeriod = 3600
        }));

        context.Handler.LastRequest.Should().NotBeNull();
        var request = context.Handler.LastRequest!;
        request.Parts.Should().ContainSingle(part => part.Name == "attach_0")
            .Which.Content.Should().Equal(0x51, 0x52);

        using var document = JsonDocument.Parse(
            request.Parts.Should().ContainSingle(part => part.Name == "content").Which.Text);
        document.RootElement.GetProperty("photo").GetString().Should().Be("attach://attach_0");
    }

    [Fact]
    public async Task SetMyProfilePhoto_WithLocalAnimation_AttachesNestedFile()
    {
        var file = await TemporaryFile.CreateAsync([0x61, 0x62]);
        await using var _ = file;
        using var context = new ClientContext();

        await context.Client.RequestAsync<bool>(new ApiRequest("setMyProfilePhoto", new SetMyProfilePhotoParameters
        {
            Photo = new InputProfilePhotoAnimated
            {
                Animation = new InputAnimationFile(file.Path),
                MainFrameTimestamp = 0.5f
            }
        }));

        context.Handler.LastRequest.Should().NotBeNull();
        var request = context.Handler.LastRequest!;
        request.Parts.Should().ContainSingle(part => part.Name == "attach_0")
            .Which.Content.Should().Equal(0x61, 0x62);

        using var document = JsonDocument.Parse(
            request.Parts.Should().ContainSingle(part => part.Name == "photo").Which.Text);
        document.RootElement.GetProperty("animation").GetString().Should().Be("attach://attach_0");
    }

    [Fact]
    public async Task UploadStickerFile_UsesTopLevelMultipartFieldName()
    {
        var file = await TemporaryFile.CreateAsync([0x71]);
        await using var _ = file;
        using var context = new ClientContext();

        await context.Client.RequestAsync<bool>(new ApiRequest("uploadStickerFile", new UploadStickerFileParameters
        {
            UserId = 123456789L,
            Sticker = new InputStickerFile(file.Path),
            StickerFormat = Endfix.Telegram.BotAPI.Enums.StickerFormat.Static
        }));

        context.Handler.LastRequest.Should().NotBeNull();
        var request = context.Handler.LastRequest!;
        request.Parts.Should().ContainSingle(part => part.Name == "sticker")
            .Which.Content.Should().Equal(0x71);
        request.Parts.Should().ContainSingle(part => part.Name == "sticker_format")
            .Which.Text.Should().Be("static");
        request.Parts.Should().NotContain(part => part.Name == "attach_0");
    }

    [Fact]
    public async Task CreateNewStickerSet_WithLocalStickers_AttachesFilesFromList()
    {
        var first = await TemporaryFile.CreateAsync([0x72]);
        await using var _ = first;
        var second = await TemporaryFile.CreateAsync([0x73]);
        await using var __ = second;
        using var context = new ClientContext();

        await context.Client.RequestAsync<bool>(new ApiRequest("createNewStickerSet", new CreateNewStickerSetParameters
        {
            UserId = 123456789L,
            Name = "contract_by_test_bot",
            Title = "Contract",
            StickerType = Endfix.Telegram.BotAPI.Enums.StickerType.Regular,
            Stickers =
            [
                new InputSticker
                {
                    Sticker = new InputStickerFile(first.Path),
                    Format = Endfix.Telegram.BotAPI.Enums.InputStickerFormat.Static,
                    EmojiList = ["one"]
                },
                new InputSticker
                {
                    Sticker = new InputStickerFile(second.Path),
                    Format = Endfix.Telegram.BotAPI.Enums.InputStickerFormat.Static,
                    EmojiList = ["two"]
                }
            ]
        }));

        context.Handler.LastRequest.Should().NotBeNull();
        var request = context.Handler.LastRequest!;
        request.Parts.Should().ContainSingle(part => part.Name == "attach_0")
            .Which.Content.Should().Equal(0x72);
        request.Parts.Should().ContainSingle(part => part.Name == "attach_1")
            .Which.Content.Should().Equal(0x73);
        request.Parts.Should().ContainSingle(part => part.Name == "sticker_type")
            .Which.Text.Should().Be("regular");

        using var document = JsonDocument.Parse(
            request.Parts.Should().ContainSingle(part => part.Name == "stickers").Which.Text);
        document.RootElement[0].GetProperty("sticker").GetString().Should().Be("attach://attach_0");
        document.RootElement[1].GetProperty("sticker").GetString().Should().Be("attach://attach_1");
    }

    [Fact]
    public async Task AddStickerToSet_WithLocalSticker_AttachesFileFromObject()
    {
        var file = await TemporaryFile.CreateAsync([0x74]);
        await using var _ = file;
        using var context = new ClientContext();

        await context.Client.RequestAsync<bool>(new ApiRequest("addStickerToSet", new AddStickerToSetParameters
        {
            UserId = 123456789L,
            Name = "contract_by_test_bot",
            Sticker = new InputSticker
            {
                Sticker = new InputStickerFile(file.Path),
                Format = Endfix.Telegram.BotAPI.Enums.InputStickerFormat.Static,
                EmojiList = ["one"]
            }
        }));

        context.Handler.LastRequest.Should().NotBeNull();
        var request = context.Handler.LastRequest!;
        request.Parts.Should().ContainSingle(part => part.Name == "attach_0")
            .Which.Content.Should().Equal(0x74);

        using var document = JsonDocument.Parse(
            request.Parts.Should().ContainSingle(part => part.Name == "sticker").Which.Text);
        document.RootElement.GetProperty("sticker").GetString().Should().Be("attach://attach_0");
    }

    [Fact]
    public async Task SendRichMessage_WithLocalMedia_AttachesFilesAcrossNestedGraph()
    {
        var explicitMedia = await TemporaryFile.CreateAsync([0x81]);
        await using var _ = explicitMedia;
        var blockMedia = await TemporaryFile.CreateAsync([0x82]);
        await using var __ = blockMedia;
        using var context = new ClientContext();

        await context.Client.RequestAsync<bool>(new ApiRequest("sendRichMessage", new SendRichMessageParameters
        {
            ChatId = 123456789L,
            RichMessage = new InputRichMessage
            {
                Blocks =
                [
                    new InputRichBlockPhoto
                    {
                        Photo = new InputMediaPhoto
                        {
                            Media = new InputPhotoFile(blockMedia.Path)
                        }
                    }
                ],
                Media =
                [
                    new InputRichMessageMedia
                    {
                        Id = "photo",
                        Media = new InputMediaPhoto
                        {
                            Media = new InputPhotoFile(explicitMedia.Path)
                        }
                    }
                ]
            }
        }));

        context.Handler.LastRequest.Should().NotBeNull();
        var request = context.Handler.LastRequest!;
        request.Parts.Should().ContainSingle(part => part.Name == "attach_0")
            .Which.Content.Should().Equal(0x81);
        request.Parts.Should().ContainSingle(part => part.Name == "attach_1")
            .Which.Content.Should().Equal(0x82);

        using var document = JsonDocument.Parse(
            request.Parts.Should().ContainSingle(part => part.Name == "rich_message").Which.Text);
        document.RootElement.GetProperty("blocks")[0].GetProperty("photo").GetProperty("media")
            .GetString().Should().Be("attach://attach_1");
        document.RootElement.GetProperty("media")[0].GetProperty("media").GetProperty("media")
            .GetString().Should().Be("attach://attach_0");
    }

    private sealed class ClientContext : IDisposable
    {
        private readonly HttpClient _httpClient;

        public ClientContext()
        {
            Handler = new RecordingHttpMessageHandler();
            _httpClient = new HttpClient(Handler);
            Client = new BotApiClient("test-token", _httpClient);
        }

        public RecordingHttpMessageHandler Handler { get; }

        public BotApiClient Client { get; }

        public void Dispose() => _httpClient.Dispose();
    }

    private sealed class RetryRecordingHandler : HttpMessageHandler
    {
        private int _requestCount;

        public List<byte[]> Attachments { get; } = [];

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            var multipart = request.Content.Should().BeOfType<MultipartFormDataContent>().Subject;
            var attachment = multipart.Single(content =>
                content.Headers.ContentDisposition?.Name?.Contains("attach_0") == true);
            Attachments.Add(await attachment.ReadAsByteArrayAsync(cancellationToken));

            var responseJson = _requestCount++ == 0
                ? "{\"ok\":false,\"error_code\":429,\"description\":\"Too Many Requests\",\"parameters\":{\"retry_after\":0}}"
                : "{\"ok\":true,\"result\":true}";

            return new HttpResponseMessage(System.Net.HttpStatusCode.OK)
            {
                Content = new StringContent(responseJson)
            };
        }
    }

    private sealed class TrackingMemoryStream(byte[] content, Action onDispose)
        : MemoryStream(content, writable: false)
    {
        private bool _disposed;

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing && !_disposed)
            {
                _disposed = true;
                onDispose();
            }
        }
    }

    private sealed class TemporaryFile(string path) : IAsyncDisposable
    {
        public string Path => path;

        public static async Task<TemporaryFile> CreateAsync(byte[] content)
        {
            var path = System.IO.Path.Combine(
                System.IO.Path.GetTempPath(),
                $"telegram-botapi-{Guid.NewGuid():N}.bin");

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
