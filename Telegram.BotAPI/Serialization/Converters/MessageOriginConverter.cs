using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Enums;
using Telegram.BotAPI.Extensions;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Serialization.Converters;

public sealed class MessageOriginConverter : JsonConverter<MessageOrigin>
{
    public override MessageOrigin Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var innerOptions = new JsonSerializerOptions(options);
        var thisConverter = innerOptions.Converters.FirstOrDefault(c => c is MessageOriginConverter);
        if (thisConverter != null)
        {
            innerOptions.Converters.Remove(thisConverter);
        }

        using var jsonDocument = JsonDocument.ParseValue(ref reader);
        var jsonElement = jsonDocument.RootElement;
        var type = jsonElement.GetProperty("type").Deserialize<MessageOriginTypes>(options);

        return type switch
        {
            MessageOriginTypes.User => jsonElement.Deserialize<MessageOriginUser>(innerOptions)!,
            MessageOriginTypes.HiddenUser => jsonElement.Deserialize<MessageOriginHiddenUser>(innerOptions)!,
            MessageOriginTypes.Chat => jsonElement.Deserialize<MessageOriginChat>(innerOptions)!,
            MessageOriginTypes.Channel => jsonElement.Deserialize<MessageOriginChannel>(innerOptions)!,
            _ => throw new JsonException($"Unknown type: {type}")
        };
    }

    public override void Write(Utf8JsonWriter writer, MessageOrigin value, JsonSerializerOptions options)
    {
        var innerOptions = new JsonSerializerOptions(options);
        var converter = innerOptions.Converters.FirstOrDefault(c => c is MessageOriginConverter);
        if (converter != null)
        {
            innerOptions.Converters.Remove(converter);
        }

        JsonSerializer.Serialize(writer, value, value.GetType(), innerOptions);
    }
}
