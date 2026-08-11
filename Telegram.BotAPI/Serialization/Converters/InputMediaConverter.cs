using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Enums;
using Telegram.BotAPI.Extensions;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Serialization.Converters;

internal sealed class InputMediaConverter : JsonConverter<InputMedia>
{
    public override InputMedia? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
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
            InputMediaType.Audio => root.Deserialize<InputMediaAudio>(options),
            InputMediaType.Document => root.Deserialize<InputMediaDocument>(options),
            InputMediaType.Link => root.Deserialize<InputMediaLink>(options),
            InputMediaType.LivePhoto => root.Deserialize<InputMediaLivePhoto>(options),
            InputMediaType.Location => root.Deserialize<InputMediaLocation>(options),
            InputMediaType.Photo => root.Deserialize<InputMediaPhoto>(options),
            InputMediaType.Sticker => root.Deserialize<InputMediaSticker>(options),
            InputMediaType.Venue => root.Deserialize<InputMediaVenue>(options),
            InputMediaType.Video => root.Deserialize<InputMediaVideo>(options),
            InputMediaType.VoiceNote => root.Deserialize<InputMediaVoiceNote>(options),
            _ => throw new JsonException($"Unknown InputMedia type: {type}")
        };
    }

    public override void Write(Utf8JsonWriter writer, InputMedia value, JsonSerializerOptions options)
    {
        if (value is null)
        {
            writer.WriteNullValue();
            return;
        }

        JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
}
