using FluentAssertions;
using Telegram.BotAPI.Parameters;
using Telegram.BotAPI.Protocol;
using Telegram.BotAPI.Tests.Infrastructure;
using Telegram.BotAPI.Types;
using Xunit;

namespace Telegram.BotAPI.Tests;

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
        var replyMarkup = request.Parts.Should()
            .ContainSingle(part => part.Name == "reply_markup")
            .Which.Text;

        replyMarkup.Should().Contain("\"inline_keyboard\"");
        replyMarkup.Should().Contain("\"callback_data\":\"open\"");
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
