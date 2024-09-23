using System.Text.Json;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Serialization.Extensions;
using Telegram.BotAPI.Structs;

namespace Telegram.BotAPI.Serialization.Converters
{
    public class BotCommandScopeConverter : JsonConverter<BotCommandScope>
    {
        public override BotCommandScope Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using var jsonDocument = JsonDocument.ParseValue(ref reader);
            var jsonElement = jsonDocument.RootElement;

            return jsonElement.GetProperty("type").GetString() switch
            {
                BotCommandScope.Types.DEFAULT => jsonElement.GetRawText().Deserialize<BotCommandScope.DefaultStruct>(),
                BotCommandScope.Types.ALL_PRIVATE_CHATS => jsonElement.GetRawText().Deserialize<BotCommandScope.AllPrivateChatsStruct>(),
                BotCommandScope.Types.ALL_GROUP_CHATS => jsonElement.GetRawText().Deserialize<BotCommandScope.AllGroupChatsStruct>(),
                BotCommandScope.Types.ALL_CHAT_ADMINISTRATORS => jsonElement.GetRawText().Deserialize<BotCommandScope.AllChatAdministratorsStruct>(),
                BotCommandScope.Types.CHAT => jsonElement.GetRawText().Deserialize<BotCommandScope.ChatStruct>(),
                BotCommandScope.Types.CHAT_ADMINISTRATORS => jsonElement.GetRawText().Deserialize<BotCommandScope.ChatAdministratorsStruct>(),
                BotCommandScope.Types.CHAT_MEMBER => jsonElement.GetRawText().Deserialize<BotCommandScope.ChatMemberStruct>(),
                _ => throw new ArgumentOutOfRangeException(jsonElement.GetRawText())
            };
        }

        public override void Write(Utf8JsonWriter writer, BotCommandScope value, JsonSerializerOptions options)
        {
            writer.WriteRawValue(value.Serialize());
        }
    }
}
