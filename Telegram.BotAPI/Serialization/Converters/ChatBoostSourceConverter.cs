using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Extensions;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Serialization.Converters;

public sealed class ChatBoostSourceConverter : JsonConverter<ChatBoostSource>
{
    public override ChatBoostSource? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var jsonDocument = JsonDocument.ParseValue(ref reader);
        var root = jsonDocument.RootElement;

        if (!root.TryGetProperty("source", out var source))
        {
            throw new JsonException("Missing discriminator 'source' in ChatBoostSource");
        }

        return source.GetString() switch
        {
            "premium" => root.Deserialize<ChatBoostSourcePremium>(options),
            "gift_code" => root.Deserialize<ChatBoostSourceGiftCode>(options),
            "giveaway" => root.Deserialize<ChatBoostSourceGiveaway>(options),
            _ => throw new JsonException($"Unknown ChatBoostSource: {source}")
        };
    }

    public override void Write(Utf8JsonWriter writer, ChatBoostSource value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
}
