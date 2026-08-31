using Endfix.Telegram.BotAPI.Enums;
using Endfix.Telegram.BotAPI.Extensions;
using Endfix.Telegram.BotAPI.Types;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Endfix.Telegram.BotAPI.Serialization.Converters;

internal sealed class InputPollMediaConverter : JsonConverter<IInputPollMedia>
{
    public override IInputPollMedia? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
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
            InputMediaType.LivePhoto => root.Deserialize<InputMediaLivePhoto>(options),
            InputMediaType.Location => root.Deserialize<InputMediaLocation>(options),
            InputMediaType.Photo => root.Deserialize<InputMediaPhoto>(options),
            InputMediaType.Venue => root.Deserialize<InputMediaVenue>(options),
            InputMediaType.Video => root.Deserialize<InputMediaVideo>(options),
            _ => throw new JsonException($"Unsupported InputPollMedia type: {type}")
        };
    }

    public override void Write(Utf8JsonWriter writer, IInputPollMedia value, JsonSerializerOptions options)
    {
        if (value is null)
        {
            writer.WriteNullValue();
            return;
        }

        if (value is not InputMedia media)
        {
            throw new JsonException($"Unsupported IInputPollMedia implementation: {value.GetType().Name}");
        }

        JsonSerializer.Serialize(writer, media, options);
    }
}
