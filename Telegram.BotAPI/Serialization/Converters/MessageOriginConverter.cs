using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Extensions;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Serialization.Converters;

public sealed class MessageOriginConverter : JsonConverter<MessageOrigin>
{
    public override MessageOrigin? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;

        if (!root.TryGetProperty("type", out var type))
        {
            throw new JsonException("Missing discriminator 'type' in MessageOrigin");
        }
        
        return type.GetString() switch
        {
            "user" => root.Deserialize<MessageOriginUser>(options),
            "hidden_user" => root.Deserialize<MessageOriginHiddenUser>(options),
            "chat" => root.Deserialize<MessageOriginChat>(options),
            "channel" => root.Deserialize<MessageOriginChannel>(options),
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
