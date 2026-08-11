using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Enums;
using Telegram.BotAPI.Extensions;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Serialization.Converters;

internal sealed class ChatBoostSourceConverter : JsonConverter<ChatBoostSource>
{
    public override ChatBoostSource? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var jsonDocument = JsonDocument.ParseValue(ref reader);
        var root = jsonDocument.RootElement;

        if (!root.TryGetProperty("source", out var sourceProperty) || !sourceProperty.TryGetEnum<ChatBoostSources>(options, out var source))
        {
            throw new JsonException("Missing discriminator 'source' in ChatBoostSource");
        }

        return source switch
        {
            ChatBoostSources.Premium => root.Deserialize<ChatBoostSourcePremium>(options),
            ChatBoostSources.GiftCode => root.Deserialize<ChatBoostSourceGiftCode>(options),
            ChatBoostSources.Giveaway => root.Deserialize<ChatBoostSourceGiveaway>(options),
            _ => throw new JsonException($"Unknown ChatBoostSource: {source}")
        };
    }

    public override void Write(Utf8JsonWriter writer, ChatBoostSource value, JsonSerializerOptions options)
    {
        if (value is null)
        {
            writer.WriteNullValue();
            return;
        }

        JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
}
