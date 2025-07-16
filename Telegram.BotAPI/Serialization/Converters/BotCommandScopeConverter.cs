using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Enums;
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
            return Enum.Parse(typeof(BotCommandScopeTypes), jsonElement.GetProperty("type").GetString()?.ToUpperInvariant()) switch
            {
                BotCommandScopeTypes.Default => jsonElement.GetRawText().Deserialize<BotCommandScopeDefault>(),
                BotCommandScopeTypes.AllPrivateChats => jsonElement.GetRawText().Deserialize<BotCommandScopeAllPrivateChats>(),
                BotCommandScopeTypes.AllGroupChats => jsonElement.GetRawText().Deserialize<BotCommandScopeAllGroupChats>(),
                BotCommandScopeTypes.AllChatAdministrators => jsonElement.GetRawText().Deserialize<BotCommandScopeAllChatAdministrators>(),
                BotCommandScopeTypes.Chat => jsonElement.GetRawText().Deserialize<BotCommandScopeChat>(),
                BotCommandScopeTypes.ChatAdministrators => jsonElement.GetRawText().Deserialize<BotCommandScopeChatAdministrators>(),
                BotCommandScopeTypes.ChatMember => jsonElement.GetRawText().Deserialize<BotCommandScopeChatMember>(),
                _ => throw new ArgumentOutOfRangeException(jsonElement.GetRawText()),
            };
        }
    }

    public override void Write(Utf8JsonWriter writer, BotCommandScope value, JsonSerializerOptions options)
    {
        writer.WriteRawValue(options.WriteIndented ? value.SerializeWithIndented() : value.Serialize());
    }
}
