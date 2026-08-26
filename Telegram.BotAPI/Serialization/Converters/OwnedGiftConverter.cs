using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Endfix.Telegram.BotAPI.Enums;
using Endfix.Telegram.BotAPI.Extensions;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Serialization.Converters;

internal sealed class OwnedGiftConverter : JsonConverter<OwnedGift>
{
    public override OwnedGift? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;

        if (!root.TryGetProperty("type", out var typeProperty) || !typeProperty.TryGetEnum<OwnedGiftType>(options, out var type))
        {
            throw new JsonException("Missing discriminator 'type' in OwnedGift");
        }

        return type switch
        {
            OwnedGiftType.Regular => root.Deserialize<OwnedGiftRegular>(options),
            OwnedGiftType.Unique => root.Deserialize<OwnedGiftUnique>(options),
            _ => throw new JsonException($"Unknown OwnedGift type: {type}")
        };
    }

    public override void Write(Utf8JsonWriter writer, OwnedGift value, JsonSerializerOptions options)
    {
        if (value is null)
        {
            writer.WriteNullValue();
            return;
        }

        JsonSerializer.Serialize(writer, (object)value, options);
    }
}
