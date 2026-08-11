using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Enums;
using Telegram.BotAPI.Extensions;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Serialization.Converters;

internal sealed class MessageOriginConverter : JsonConverter<MessageOrigin>
{
    public override MessageOrigin? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;

        if (!root.TryGetProperty("type", out var typeProperty) || !typeProperty.TryGetEnum<MessageOriginType>(options, out var type))
        {
            throw new JsonException("Missing discriminator 'type' in MessageOrigin");
        }
        
        return type switch
        {
            MessageOriginType.User => root.Deserialize<MessageOriginUser>(options),
            MessageOriginType.HiddenUser => root.Deserialize<MessageOriginHiddenUser>(options),
            MessageOriginType.Chat => root.Deserialize<MessageOriginChat>(options),
            MessageOriginType.Channel => root.Deserialize<MessageOriginChannel>(options),
            _ => throw new JsonException($"Unknown MessageOrigin type: {type}")
        };
    }

    public override void Write(Utf8JsonWriter writer, MessageOrigin value, JsonSerializerOptions options)
    {
        if (value is null)
        {
            writer.WriteNullValue();
            return;
        }

        JsonSerializer.Serialize(writer, (object)value, options);
    }
}
