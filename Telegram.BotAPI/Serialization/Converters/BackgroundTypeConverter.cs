using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Endfix.Telegram.BotAPI.Enums;
using Endfix.Telegram.BotAPI.Extensions;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Serialization.Converters;

internal sealed class BackgroundTypeConverter : JsonConverter<BackgroundType>
{
    public override BackgroundType? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var jsonDocument = JsonDocument.ParseValue(ref reader);
        var root = jsonDocument.RootElement;

        if (!root.TryGetProperty("type", out var typeProperty) || !typeProperty.TryGetEnum<BackgroundTypes>(options, out var type))
        {
            throw new JsonException("Missing discriminator 'type' in BackgroundType");
        }

        return type switch
        {
            BackgroundTypes.Fill => root.Deserialize<BackgroundTypeFill>(options),
            BackgroundTypes.Wallpaper => root.Deserialize<BackgroundTypeWallpaper>(options),
            BackgroundTypes.Pattern => root.Deserialize<BackgroundTypePattern>(options),
            BackgroundTypes.ChatTheme => root.Deserialize<BackgroundTypeChatTheme>(options),
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
