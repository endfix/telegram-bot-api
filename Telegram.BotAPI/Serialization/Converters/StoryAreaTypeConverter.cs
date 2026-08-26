using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Endfix.Telegram.BotAPI.Enums;
using Endfix.Telegram.BotAPI.Extensions;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Serialization.Converters;

internal sealed class StoryAreaTypeConverter : JsonConverter<StoryAreaType>
{
    public override StoryAreaType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var jsonDocument = JsonDocument.ParseValue(ref reader);
        var root = jsonDocument.RootElement;

        if (!root.TryGetProperty("type", out var typeProperty) || !typeProperty.TryGetEnum<StoryAreaTypes>(options, out var type))
        {
            throw new JsonException("Missing discriminator 'type' in StoryAreaType");
        }

        return type switch
        {
            StoryAreaTypes.Location => root.Deserialize<StoryAreaTypeLocation>(options)!,
            StoryAreaTypes.SuggestedReaction => root.Deserialize<StoryAreaTypeSuggestedReaction>(options)!,
            StoryAreaTypes.Link => root.Deserialize<StoryAreaTypeLink>(options)!,
            StoryAreaTypes.Weather => root.Deserialize<StoryAreaTypeWeather>(options)!,
            StoryAreaTypes.UniqueGift => root.Deserialize<StoryAreaTypeUniqueGift>(options)!,
            _ => throw new JsonException($"Unknown StoryAreaType type: {type}")
        };
    }

    public override void Write(Utf8JsonWriter writer, StoryAreaType value, JsonSerializerOptions options)
    {
        if (value is null)
        {
            writer.WriteNullValue();
            return;
        }

        JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
}
