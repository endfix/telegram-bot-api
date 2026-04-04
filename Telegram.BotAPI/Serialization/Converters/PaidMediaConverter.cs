using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Extensions;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Serialization.Converters;

public sealed class PaidMediaConverter : JsonConverter<PaidMedia>
{
    public override PaidMedia? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;

        if (!root.TryGetProperty("type", out var type))
        {
            throw new JsonException("Missing discriminator 'type' in PaidMedia");
        }

        return type.GetString() switch
        {
            "photo" => root.Deserialize<PaidMediaPhoto>(options),
            "video" => root.Deserialize<PaidMediaVideo>(options),
            "preview" => root.Deserialize<PaidMediaPreview>(options),
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
