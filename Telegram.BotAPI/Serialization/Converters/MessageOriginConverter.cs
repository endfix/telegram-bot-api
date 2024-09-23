using System.Text.Json;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Structs;
using Telegram.BotAPI.Serialization.Extensions;

namespace Telegram.BotAPI.Serialization.Converters
{
    public class MessageOriginConverter : JsonConverter<MessageOrigin>
    {
        public override MessageOrigin Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using var jsonDocument = JsonDocument.ParseValue(ref reader);
            var jsonElement = jsonDocument.RootElement;

            return jsonElement.GetProperty("type").GetString() switch
            {
                MessageOrigin.Types.USER => jsonElement.GetRawText().Deserialize<MessageOrigin.UserStruct>(),
                MessageOrigin.Types.HIDDEN_USER => jsonElement.GetRawText().Deserialize<MessageOrigin.HiddenUserStruct>(),
                MessageOrigin.Types.CHAT => jsonElement.GetRawText().Deserialize<MessageOrigin.ChatStruct>(),
                MessageOrigin.Types.CHANNEL => jsonElement.GetRawText().Deserialize<MessageOrigin.ChannelStruct>(),
                _ => throw new ArgumentOutOfRangeException(jsonElement.GetRawText())
            };
        }

        public override void Write(Utf8JsonWriter writer, MessageOrigin value, JsonSerializerOptions options)
        {
            writer.WriteRawValue(value.Serialize());
        }
    }
}
