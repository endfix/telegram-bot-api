using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Extensions;
using Telegram.BotAPI.Types;
using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Serialization.Converters;

public class MessageOriginConverter : JsonConverter<MessageOrigin>
{
    public override MessageOrigin Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using (var jsonDocument = JsonDocument.ParseValue(ref reader))
        {
            var jsonElement = jsonDocument.RootElement;
            return Enum.Parse(typeof(MessageOriginTypes), jsonElement.GetProperty("type").GetString()?.ToUpperInvariant()) switch
            {
                MessageOriginTypes.User => jsonElement.GetRawText().Deserialize<MessageOriginUser>(),
                MessageOriginTypes.HiddenUser => jsonElement.GetRawText().Deserialize<MessageOriginHiddenUser>(),
                MessageOriginTypes.Chat => jsonElement.GetRawText().Deserialize<MessageOriginChat>(),
                MessageOriginTypes.Channel => jsonElement.GetRawText().Deserialize<MessageOriginChannel>(),
                _ => throw new ArgumentOutOfRangeException(jsonElement.GetRawText()),
            };
        }
    }

    public override void Write(Utf8JsonWriter writer, MessageOrigin value, JsonSerializerOptions options)
    {
        writer.WriteRawValue(value.Serialize(options.WriteIndented));
    }
}
