using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Enums;
using Telegram.BotAPI.Extensions;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Serialization.Converters;

public sealed class ChatBoostSourceConverter : JsonConverter<ChatBoostSource>
{
    public override ChatBoostSource Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var innerOptions = new JsonSerializerOptions(options);
        var thisConverter = innerOptions.Converters.FirstOrDefault(c => c is ChatBoostSourceConverter);
        if (thisConverter != null)
        {
            innerOptions.Converters.Remove(thisConverter);
        }

        using var jsonDocument = JsonDocument.ParseValue(ref reader);
        var jsonElement = jsonDocument.RootElement;
        var source = jsonElement.GetProperty("source").Deserialize<ChatBoostSources>(options);

        return source switch
        {
            ChatBoostSources.Premium => jsonElement.Deserialize<ChatBoostSourcePremium>(innerOptions)!,
            ChatBoostSources.GiftCode => jsonElement.Deserialize<ChatBoostSourceGiftCode>(innerOptions)!,
            ChatBoostSources.Giveaway => jsonElement.Deserialize<ChatBoostSourceGiveaway>(innerOptions)!,
            _ => throw new JsonException($"Unknown type: {source}")
        };
    }

    public override void Write(Utf8JsonWriter writer, ChatBoostSource value, JsonSerializerOptions options)
    {
        var innerOptions = new JsonSerializerOptions(options);
        var converter = innerOptions.Converters.FirstOrDefault(c => c is ChatBoostSourceConverter);
        if (converter != null)
        {
            innerOptions.Converters.Remove(converter);
        }

        JsonSerializer.Serialize(writer, value, value.GetType(), innerOptions);
    }
}
