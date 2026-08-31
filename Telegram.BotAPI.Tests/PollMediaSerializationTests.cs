using System.Text.Json;
using Endfix.Telegram.BotAPI.Extensions;
using Endfix.Telegram.BotAPI.Parameters;
using Endfix.Telegram.BotAPI.Types;
using Xunit;

namespace Endfix.Telegram.BotAPI.Tests;

public sealed class PollMediaSerializationTests
{
    public static TheoryData<IInputPollMedia, string> PollMediaValues => new()
    {
        { new InputMediaAnimation { Media = "animation-id" }, "animation" },
        { new InputMediaAudio { Media = "audio-id" }, "audio" },
        { new InputMediaDocument { Media = "document-id" }, "document" },
        {
            new InputMediaLivePhoto
            {
                Media = "live-photo-video-id",
                Photo = "live-photo-image-id"
            },
            "live_photo"
        },
        { new InputMediaLocation { Latitude = 55.75, Longitude = 37.62 }, "location" },
        { new InputMediaPhoto { Media = "photo-id" }, "photo" },
        {
            new InputMediaVenue
            {
                Latitude = 55.75,
                Longitude = 37.62,
                Title = "Venue",
                Address = "Test address"
            },
            "venue"
        },
        { new InputMediaVideo { Media = "video-id" }, "video" }
    };

    public static TheoryData<IInputPollOptionMedia, string> PollOptionMediaValues => new()
    {
        { new InputMediaAnimation { Media = "animation-id" }, "animation" },
        { new InputMediaLink { Url = "https://example.com/media" }, "link" },
        {
            new InputMediaLivePhoto
            {
                Media = "live-photo-video-id",
                Photo = "live-photo-image-id"
            },
            "live_photo"
        },
        { new InputMediaLocation { Latitude = 55.75, Longitude = 37.62 }, "location" },
        { new InputMediaPhoto { Media = "photo-id" }, "photo" },
        { new InputMediaSticker { Media = "sticker-id", Emoji = "test" }, "sticker" },
        {
            new InputMediaVenue
            {
                Latitude = 55.75,
                Longitude = 37.62,
                Title = "Venue",
                Address = "Test address"
            },
            "venue"
        },
        { new InputMediaVideo { Media = "video-id" }, "video" }
    };

    [Theory]
    [MemberData(nameof(PollMediaValues))]
    public void PollMedia_RoundtripsInsideSendPollParameters(
        IInputPollMedia value,
        string discriminator)
    {
        var parameters = new SendPollParameters
        {
            ChatId = 1,
            Question = "Question",
            Options = [new InputPollOption { Text = "Option" }],
            Media = value
        };

        var json = parameters.Serialize();
        using var document = JsonDocument.Parse(json);
        Assert.Equal(discriminator, document.RootElement.GetProperty("media").GetProperty("type").GetString());

        var roundtrip = json.Deserialize<SendPollParameters>();
        Assert.IsType(value.GetType(), roundtrip!.Media);
    }

    [Theory]
    [MemberData(nameof(PollOptionMediaValues))]
    public void PollOptionMedia_RoundtripsInsidePollOption(
        IInputPollOptionMedia value,
        string discriminator)
    {
        var option = new InputPollOption
        {
            Text = "Option",
            Media = value
        };

        var json = option.Serialize();
        using var document = JsonDocument.Parse(json);
        Assert.Equal(discriminator, document.RootElement.GetProperty("media").GetProperty("type").GetString());

        var roundtrip = json.Deserialize<InputPollOption>();
        Assert.IsType(value.GetType(), roundtrip!.Media);
    }

    [Fact]
    public void PollMedia_RejectsOptionOnlyType()
        => Assert.Throws<JsonException>(() =>
            """{"type":"link","url":"https://example.com/media"}"""
                .Deserialize<IInputPollMedia>());

    [Fact]
    public void PollOptionMedia_RejectsPollOnlyType()
        => Assert.Throws<JsonException>(() =>
            """{"type":"audio","media":"audio-id"}"""
                .Deserialize<IInputPollOptionMedia>());

    [Theory]
    [InlineData("""{"type":"link","url":"https://example.com/media"}""")]
    [InlineData("""{"type":"location","latitude":55.75,"longitude":37.62}""")]
    [InlineData("""{"type":"venue","latitude":55.75,"longitude":37.62,"title":"Venue","address":"Address"}""")]
    public void NonFileMedia_DoesNotRequireOrEmitMedia(string json)
    {
        var value = json.Deserialize<InputMedia>();
        var roundtrip = value!.Serialize();

        using var document = JsonDocument.Parse(roundtrip);
        Assert.False(document.RootElement.TryGetProperty("media", out _));
        Assert.False(document.RootElement.TryGetProperty("caption", out _));
    }

    [Fact]
    public void PollMedia_RejectsUnknownInterfaceImplementation()
        => Assert.Throws<JsonException>(() =>
            new PollMediaEnvelope { Media = new UnsupportedPollMedia() }.Serialize());

    private sealed class PollMediaEnvelope
    {
        public required IInputPollMedia Media { get; init; }
    }

    private sealed class UnsupportedPollMedia : IInputPollMedia
    {
    }
}
