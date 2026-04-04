using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Extensions;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Serialization.Converters;

public sealed class BackgroundTypeConverter : JsonConverter<BackgroundType>
{
    public override BackgroundType? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var jsonDocument = JsonDocument.ParseValue(ref reader);
        var root = jsonDocument.RootElement;

        if (!root.TryGetProperty("type", out var type))
        {
            throw new JsonException("Missing discriminator 'type' in BackgroundType");
        }

        return type.GetString() switch
        {
            "fill" => root.Deserialize<BackgroundTypeFill>(options),
            "wallpaper" => root.Deserialize<BackgroundTypeWallpaper>(options),
            "pattern" => root.Deserialize<BackgroundTypePattern>(options),
            "chat_theme" => root.Deserialize<BackgroundTypeChatTheme>(options),
            _ => throw new JsonException($"Unknown BackgroundType: {type}")
        };
    }

    public override void Write(Utf8JsonWriter writer, BackgroundType value, JsonSerializerOptions options)
    {
        if (value is null)
        {
            writer.WriteNullValue();
            return;
        }

        JsonSerializer.Serialize(writer, (object)value, options);
    }
}
