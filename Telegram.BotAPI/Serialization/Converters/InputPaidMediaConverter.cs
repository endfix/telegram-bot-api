using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Enums;
using Telegram.BotAPI.Extensions;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Serialization.Converters;

internal sealed class InputPaidMediaConverter : JsonConverter<InputPaidMedia>
{
    public override InputPaidMedia Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var jsonDocument = JsonDocument.ParseValue(ref reader);
        var root = jsonDocument.RootElement;

        if (!root.TryGetProperty("type", out var typeProperty) || !typeProperty.TryGetEnum<InputPaidMediaType>(options, out var type))
        {
            throw new JsonException("Missing discriminator 'type' in InputPaidMedia");
        }

        return type switch
        {
            InputPaidMediaType.LivePhoto => root.Deserialize<InputPaidMediaLivePhoto>(options)!,
            InputPaidMediaType.Photo => root.Deserialize<InputPaidMediaPhoto>(options)!,
            InputPaidMediaType.Video => root.Deserialize<InputPaidMediaVideo>(options)!,
            _ => throw new JsonException($"Unknown InputPaidMedia type: {type}")
        };
    }

    public override void Write(Utf8JsonWriter writer, InputPaidMedia value, JsonSerializerOptions options)
    {
        if (value is null)
        {
            writer.WriteNullValue();
            return;
        }

        JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
}
