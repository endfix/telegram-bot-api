using Endfix.Telegram.BotAPI.Enums;
using Endfix.Telegram.BotAPI.Extensions;
using Endfix.Telegram.BotAPI.Types;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Endfix.Telegram.BotAPI.Serialization.Converters;

internal sealed class EmojiTypeConverter : JsonConverter<EmojiType>
{
    public override EmojiType? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var jsonDocument = JsonDocument.ParseValue(ref reader);
        var root = jsonDocument.RootElement;

        if (!root.TryGetProperty("type", out var typeProperty) || !typeProperty.TryGetEnum<EmojiTypes>(options, out var type))
        {
            throw new JsonException("Missing discriminator 'type' in EmojiType");
        }

        return type switch
        {
            EmojiTypes.Emoji => root.Deserialize<EmojiTypeEmoji>(options),
            EmojiTypes.CustomEmoji => root.Deserialize<EmojiTypeCustomEmoji>(options),
            _ => throw new JsonException($"Unknown EmojiType: {type}")
        };
    }

    public override void Write(Utf8JsonWriter writer, EmojiType value, JsonSerializerOptions options)
    {
        if (value is null)
        {
            writer.WriteNullValue();
            return;
        }

        JsonSerializer.Serialize(writer, (object)value, options);
    }
}
