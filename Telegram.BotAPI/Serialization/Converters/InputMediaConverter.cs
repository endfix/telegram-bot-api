using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Extensions;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Serialization.Converters;

public sealed class InputMediaConverter : JsonConverter<InputMedia>
{
    public override InputMedia? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var jsonDocument = JsonDocument.ParseValue(ref reader);
        var root = jsonDocument.RootElement;

        if (!root.TryGetProperty("type", out var type))
        {
            throw new JsonException("Missing discriminator 'type' in InputMedia");
        }

        return type.GetString() switch
        {
            "animation" => root.Deserialize<InputMediaAnimation>(options),
            "document" => root.Deserialize<InputMediaDocument>(options),
            "audio" => root.Deserialize<InputMediaAudio>(options),
            "photo" => root.Deserialize<InputMediaPhoto>(options),
            "video" => root.Deserialize<InputMediaVideo>(options),
            _ => throw new JsonException($"Unknown InputMedia type: {type}")
        };
    }

    public override void Write(Utf8JsonWriter writer, InputMedia value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
}
