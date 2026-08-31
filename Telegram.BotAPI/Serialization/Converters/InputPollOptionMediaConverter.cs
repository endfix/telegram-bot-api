using Endfix.Telegram.BotAPI.Enums;
using Endfix.Telegram.BotAPI.Extensions;
using Endfix.Telegram.BotAPI.Types;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Endfix.Telegram.BotAPI.Serialization.Converters;

internal sealed class InputPollOptionMediaConverter : JsonConverter<IInputPollOptionMedia>
{
    public override IInputPollOptionMedia? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var jsonDocument = JsonDocument.ParseValue(ref reader);
        var root = jsonDocument.RootElement;

        if (!root.TryGetProperty("type", out var typeProperty) || !typeProperty.TryGetEnum<InputMediaType>(options, out var type))
        {
            throw new JsonException("Missing discriminator 'type' in InputMedia");
        }

        return type switch
        {
            InputMediaType.Animation => root.Deserialize<InputMediaAnimation>(options),
            InputMediaType.Link => root.Deserialize<InputMediaLink>(options),
            InputMediaType.LivePhoto => root.Deserialize<InputMediaLivePhoto>(options),
            InputMediaType.Location => root.Deserialize<InputMediaLocation>(options),
            InputMediaType.Photo => root.Deserialize<InputMediaPhoto>(options),
            InputMediaType.Sticker => root.Deserialize<InputMediaSticker>(options),
            InputMediaType.Venue => root.Deserialize<InputMediaVenue>(options),
            InputMediaType.Video => root.Deserialize<InputMediaVideo>(options),
            _ => throw new JsonException($"Unsupported InputPollOptionMedia type: {type}")
        };
    }

    public override void Write(Utf8JsonWriter writer, IInputPollOptionMedia value, JsonSerializerOptions options)
    {
        if (value is null)
        {
            writer.WriteNullValue();
            return;
        }

        if (value is not InputMedia media)
        {
            throw new JsonException($"Unsupported IInputPollOptionMedia implementation: {value.GetType().Name}");
        }

        JsonSerializer.Serialize(writer, media, options);
    }
}
