using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Extensions;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Serialization.Converters;

public sealed class ReactionTypeConverter : JsonConverter<ReactionType>
{
    public override ReactionType? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;

        if (!root.TryGetProperty("type", out var type))
        {
            throw new JsonException("Missing discriminator 'type' in ReactionType");
        }

        return type.GetString() switch
        {
            "emoji" => root.Deserialize<ReactionTypeEmoji>(options),
            "custom_emoji" => root.Deserialize<ReactionTypeCustomEmoji>(options),
            "paid" => root.Deserialize<ReactionTypePaid>(options),
            _ => throw new JsonException($"Unknown ReactionType: {type}")
        };
    }

    public override void Write(Utf8JsonWriter writer, ReactionType value, JsonSerializerOptions options)
    {
        if (value is null)
        {
            writer.WriteNullValue();
            return;
        }

        JsonSerializer.Serialize(writer, (object)value, options);
    }
}
