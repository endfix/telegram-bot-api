using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Extensions;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Serialization.Converters;

public class BotCommandScopeConverter : JsonConverter<BotCommandScope>
{
    public override BotCommandScope Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using (var jsonDocument = JsonDocument.ParseValue(ref reader))
        {
            var jsonElement = jsonDocument.RootElement;

            return jsonElement.GetProperty("type").GetString() switch
            {
                BotCommandScope.Types.DEFAULT => jsonElement.GetRawText().Deserialize<BotCommandScopeDefault>(),
                BotCommandScope.Types.ALL_PRIVATE_CHATS => jsonElement.GetRawText().Deserialize<BotCommandScopeAllPrivateChats>(),
                BotCommandScope.Types.ALL_GROUP_CHATS => jsonElement.GetRawText().Deserialize<BotCommandScopeAllGroupChats>(),
                BotCommandScope.Types.ALL_CHAT_ADMINISTRATORS => jsonElement.GetRawText().Deserialize<BotCommandScopeAllChatAdministrators>(),
                BotCommandScope.Types.CHAT => jsonElement.GetRawText().Deserialize<BotCommandScopeChat>(),
                BotCommandScope.Types.CHAT_ADMINISTRATORS => jsonElement.GetRawText().Deserialize<BotCommandScopeChatAdministrators>(),
                BotCommandScope.Types.CHAT_MEMBER => jsonElement.GetRawText().Deserialize<BotCommandScopeChatMember>(),
                _ => throw new ArgumentOutOfRangeException(jsonElement.GetRawText()),
            };
        }
    }

    public override void Write(Utf8JsonWriter writer, BotCommandScope value, JsonSerializerOptions options)
    {
        writer.WriteRawValue(value.Serialize());
    }
}
