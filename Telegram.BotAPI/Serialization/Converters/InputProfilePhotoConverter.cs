using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Enums;
using Telegram.BotAPI.Extensions;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Serialization.Converters;

internal sealed class InputProfilePhotoConverter : JsonConverter<InputProfilePhoto>
{
    public override InputProfilePhoto Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var jsonDocument = JsonDocument.ParseValue(ref reader);
        var root = jsonDocument.RootElement;

        if (!root.TryGetProperty("type", out var typeProperty) || !typeProperty.TryGetEnum<InputProfilePhotoType>(options, out var type))
        {
            throw new JsonException("Missing discriminator 'type' in InputProfilePhoto");
        }

        return type switch
        {
            InputProfilePhotoType.Static => root.Deserialize<InputProfilePhotoStatic>(options)!,
            InputProfilePhotoType.Animated => root.Deserialize<InputProfilePhotoAnimated>(options)!,
            _ => throw new JsonException($"Unknown InputProfilePhoto type: {type}")
        };
    }

    public override void Write(Utf8JsonWriter writer, InputProfilePhoto value, JsonSerializerOptions options)
    {
        if (value is null)
        {
            writer.WriteNullValue();
            return;
        }

        JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
}
