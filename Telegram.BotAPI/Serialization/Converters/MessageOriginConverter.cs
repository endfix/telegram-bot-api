using System.Text.Json;
using System.Text.Json.Serialization;
using System;
using Telegram.BotAPI.Extensions;
using Telegram.BotAPI.Types.AvailableTypes;

namespace Telegram.BotAPI.Serialization.Converters;

public class MessageOriginConverter : JsonConverter<MessageOrigin>
{
    public override MessageOrigin Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using (var jsonDocument = JsonDocument.ParseValue(ref reader))
        {
            var jsonElement = jsonDocument.RootElement;

            return jsonElement.GetProperty("type").GetString() switch
            {
                MessageOrigin.Types.USER => jsonElement.GetRawText().Deserialize<MessageOriginUser>(),
                MessageOrigin.Types.HIDDEN_USER => jsonElement.GetRawText().Deserialize<MessageOriginHiddenUser>(),
                MessageOrigin.Types.CHAT => jsonElement.GetRawText().Deserialize<MessageOriginChat>(),
                MessageOrigin.Types.CHANNEL => jsonElement.GetRawText().Deserialize<MessageOriginChannel>(),
                _ => throw new ArgumentOutOfRangeException(jsonElement.GetRawText()),
            };
        }
    }

    public override void Write(Utf8JsonWriter writer, MessageOrigin value, JsonSerializerOptions options)
    {
        writer.WriteRawValue(value.Serialize());
    }
}
