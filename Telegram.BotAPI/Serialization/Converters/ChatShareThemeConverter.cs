using Endfix.Telegram.BotAPI.Enums;
using Endfix.Telegram.BotAPI.Extensions;
using Endfix.Telegram.BotAPI.Types;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Endfix.Telegram.BotAPI.Serialization.Converters;

internal sealed class ChatShareThemeConverter : JsonConverter<ChatShareTheme>
{
    public override ChatShareTheme? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var jsonDocument = JsonDocument.ParseValue(ref reader);
        var root = jsonDocument.RootElement;

        if (!root.TryGetProperty("type", out var typeProperty) || !typeProperty.TryGetEnum<ChatShareThemeType>(options, out var type))
        {
            throw new JsonException("Missing discriminator 'type' in ChatShareTheme");
        }

        return type switch
        {
            ChatShareThemeType.Emoji => root.Deserialize<ChatShareThemeEmoji>(options),
            ChatShareThemeType.UniqueGift => root.Deserialize<ChatShareThemeUniqueGift>(options),
            _ => throw new JsonException($"Unknown ChatShareTheme type: {type}")
        };
    }

    public override void Write(Utf8JsonWriter writer, ChatShareTheme value, JsonSerializerOptions options)
    {
        if (value is null)
        {
            writer.WriteNullValue();
            return;
        }

        JsonSerializer.Serialize(writer, (object)value, options);
    }
}
