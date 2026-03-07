using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Enums;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Serialization.Converters;

public sealed class OwnedGiftConverter : JsonConverter<OwnedGift>
{
    public override OwnedGift Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var innerOptions = new JsonSerializerOptions(options);
        var thisConverter = innerOptions.Converters.FirstOrDefault(c => c is OwnedGiftConverter);
        if (thisConverter != null)
        {
            innerOptions.Converters.Remove(thisConverter);
        }

        using var jsonDocument = JsonDocument.ParseValue(ref reader);
        var jsonElement = jsonDocument.RootElement;
        var type = jsonElement.GetProperty("type").Deserialize<OwnedGiftTypes>(options);

        return type switch
        {
            OwnedGiftTypes.Regular => jsonElement.Deserialize<OwnedGiftRegular>(innerOptions)!,
            OwnedGiftTypes.Unique => jsonElement.Deserialize<OwnedGiftUnique>(innerOptions)!,
            _ => throw new JsonException($"Unknown type: {type}")
        };
    }

    public override void Write(Utf8JsonWriter writer, OwnedGift value, JsonSerializerOptions options)
    {
        var innerOptions = new JsonSerializerOptions(options);
        var converter = innerOptions.Converters.FirstOrDefault(c => c is OwnedGiftConverter);
        if (converter != null)
        {
            innerOptions.Converters.Remove(converter);
        }

        JsonSerializer.Serialize(writer, value, value.GetType(), innerOptions);
    }
}
