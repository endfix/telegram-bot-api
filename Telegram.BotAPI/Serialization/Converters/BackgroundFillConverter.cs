using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Enums;
using Telegram.BotAPI.Extensions;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Serialization.Converters;

public sealed class BackgroundFillConverter : JsonConverter<BackgroundFill>
{
    public override BackgroundFill? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var jsonDocument = JsonDocument.ParseValue(ref reader);
        var root = jsonDocument.RootElement;

        if (!root.TryGetProperty("type", out var typeProperty) || !typeProperty.TryGetEnum<BackgroundFillType>(options, out var type))
        {
            throw new JsonException("Missing discriminator 'type' in BackgroundFill");
        }

        return type switch
        {
            BackgroundFillType.Solid => root.Deserialize<BackgroundFillSolid>(options),
            BackgroundFillType.Gradient => root.Deserialize<BackgroundFillGradient>(options),
            BackgroundFillType.FreeformGradient => root.Deserialize<BackgroundFillFreeformGradient>(options),
            _ => throw new JsonException($"Unknown BackgroundFill type: {type}")
        };
    }

    public override void Write(Utf8JsonWriter writer, BackgroundFill value, JsonSerializerOptions options)
    {
        if (value is null)
        {
            writer.WriteNullValue();
            return;
        }

        JsonSerializer.Serialize(writer, (object)value, options);
    }
}
