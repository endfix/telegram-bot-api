using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Endfix.Telegram.BotAPI.Enums;
using Endfix.Telegram.BotAPI.Extensions;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Serialization.Converters;

internal class InputStoryContentConverter : JsonConverter<InputStoryContent>
{
    public override InputStoryContent Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var jsonDocument = JsonDocument.ParseValue(ref reader);
        var root = jsonDocument.RootElement;

        if (!root.TryGetProperty("type", out var typeProperty) || !typeProperty.TryGetEnum<InputStoryContentType>(options, out var type))
        {
            throw new JsonException("Missing discriminator 'type' in InputStoryContent");
        }

        return type switch
        {
            InputStoryContentType.Photo => root.Deserialize<InputStoryContentPhoto>(options)!,
            InputStoryContentType.Video => root.Deserialize<InputStoryContentVideo>(options)!,
            _ => throw new JsonException($"Unknown InputStoryContent type: {type}")
        };
    }

    public override void Write(Utf8JsonWriter writer, InputStoryContent value, JsonSerializerOptions options)
    {
        if (value is null)
        {
            writer.WriteNullValue();
            return;
        }

        JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
}
