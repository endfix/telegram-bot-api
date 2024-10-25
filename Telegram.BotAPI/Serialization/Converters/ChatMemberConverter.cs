using System;
using System.Text.Json;
using System.Text.Json.Serialization;
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

            return jsonElement.GetProperty("status").GetString() switch
            {
                ChatMember.Statuses.CREATOR => jsonElement.GetRawText().Deserialize<ChatMemberOwner>(),
                ChatMember.Statuses.ADMINISTRATOR => jsonElement.GetRawText().Deserialize<ChatMemberAdministrator>(),
                ChatMember.Statuses.MEMBER => jsonElement.GetRawText().Deserialize<ChatMemberMember>(),
                ChatMember.Statuses.RESTRICTED => jsonElement.GetRawText().Deserialize<ChatMemberRestricted>(),
                ChatMember.Statuses.LEFT => jsonElement.GetRawText().Deserialize<ChatMemberLeft>(),
                ChatMember.Statuses.KICKED => jsonElement.GetRawText().Deserialize<ChatMemberBanned>(),
                _ => throw new ArgumentOutOfRangeException(jsonElement.GetRawText()),
            };
        }
    }

    public override void Write(Utf8JsonWriter writer, ChatMember value, JsonSerializerOptions options)
    {
        writer.WriteRawValue(value.Serialize());
    }
}
