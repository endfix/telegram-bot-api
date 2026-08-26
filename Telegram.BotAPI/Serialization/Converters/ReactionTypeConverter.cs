using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Endfix.Telegram.BotAPI.Enums;
using Endfix.Telegram.BotAPI.Extensions;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Serialization.Converters;

internal sealed class ReactionTypeConverter : JsonConverter<ReactionType>
{
    public override ReactionType? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;

        if (!root.TryGetProperty("type", out var typeProperty) || !typeProperty.TryGetEnum<ReactionTypes>(options, out var type))
        {
            throw new JsonException("Missing discriminator 'type' in ReactionType");
        }

        return type switch
        {
            ReactionTypes.Emoji => root.Deserialize<ReactionTypeEmoji>(options),
            ReactionTypes.CustomEmoji => root.Deserialize<ReactionTypeCustomEmoji>(options),
            ReactionTypes.Paid => root.Deserialize<ReactionTypePaid>(options),
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
