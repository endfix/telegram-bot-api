using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Enums;
using Telegram.BotAPI.Extensions;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Serialization.Converters;

public class ChatMemberConverter : JsonConverter<ChatMember>
{
    public override ChatMember Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using (var jsonDocument = JsonDocument.ParseValue(ref reader))
        {
            var jsonElement = jsonDocument.RootElement;
            return Enum.Parse(typeof(ChatMemberStatus), jsonElement.GetProperty("status").GetString()?.ToUpperInvariant()) switch
            {
                ChatMemberStatus.Creator => jsonElement.GetRawText().Deserialize<ChatMemberOwner>(),
                ChatMemberStatus.Administrator => jsonElement.GetRawText().Deserialize<ChatMemberAdministrator>(),
                ChatMemberStatus.Member => jsonElement.GetRawText().Deserialize<ChatMemberMember>(),
                ChatMemberStatus.Restricted => jsonElement.GetRawText().Deserialize<ChatMemberRestricted>(),
                ChatMemberStatus.Left => jsonElement.GetRawText().Deserialize<ChatMemberLeft>(),
                ChatMemberStatus.Kicked => jsonElement.GetRawText().Deserialize<ChatMemberBanned>(),
                _ => throw new ArgumentOutOfRangeException(jsonElement.GetRawText()),
            };
        }
    }

    public override void Write(Utf8JsonWriter writer, ChatMember value, JsonSerializerOptions options)
    {
        writer.WriteRawValue(value.Serialize(options.WriteIndented));
    }
}
