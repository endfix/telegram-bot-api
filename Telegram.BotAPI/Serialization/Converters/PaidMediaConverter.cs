using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Enums;
using Telegram.BotAPI.Extensions;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Serialization.Converters;

internal sealed class PaidMediaConverter : JsonConverter<PaidMedia>
{
    public override PaidMedia? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;

        if (!root.TryGetProperty("type", out var typeProperty) || !typeProperty.TryGetEnum<PaidMediaType>(options, out var type))
        {
            throw new JsonException("Missing discriminator 'type' in PaidMedia");
        }

        return type switch
        {
            PaidMediaType.LivePhoto => root.Deserialize<PaidMediaLivePhoto>(options),
            PaidMediaType.Photo => root.Deserialize<PaidMediaPhoto>(options),
            PaidMediaType.Video => root.Deserialize<PaidMediaVideo>(options),
            PaidMediaType.Preview => root.Deserialize<PaidMediaPreview>(options),
            _ => throw new JsonException($"Unknown PaidMedia type: {type}")
        };
    }

    public override void Write(Utf8JsonWriter writer, PaidMedia value, JsonSerializerOptions options)
    {
        if (value is null)
        {
            writer.WriteNullValue();
            return;
        }

        JsonSerializer.Serialize(writer, (object)value, options);
    }
}
