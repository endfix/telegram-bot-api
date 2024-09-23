using System.Text.Json;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Structs;
using Telegram.BotAPI.Serialization.Extensions;

namespace Telegram.BotAPI.Serialization.Converters
{
    public class ChatMemberConverter : JsonConverter<ChatMember>
    {
        public override ChatMember Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using var jsonDocument = JsonDocument.ParseValue(ref reader);
            var jsonElement = jsonDocument.RootElement;

            return jsonElement.GetProperty("status").GetString() switch
            {
                ChatMember.Types.CREATOR => jsonElement.GetRawText().Deserialize<ChatMember.OwnerStruct>(),
                ChatMember.Types.ADMINISTRATOR => jsonElement.GetRawText().Deserialize<ChatMember.AdministratorStruct>(),
                ChatMember.Types.MEMBER => jsonElement.GetRawText().Deserialize<ChatMember.MemberStruct>(),
                ChatMember.Types.RESTRICTED => jsonElement.GetRawText().Deserialize<ChatMember.RestrictedStruct>(),
                ChatMember.Types.LEFT => jsonElement.GetRawText().Deserialize<ChatMember.LeftStruct>(),
                ChatMember.Types.KICKED => jsonElement.GetRawText().Deserialize<ChatMember.BannedStruct>(),
                _ => throw new ArgumentOutOfRangeException(jsonElement.GetRawText())
            };
        }

        public override void Write(Utf8JsonWriter writer, ChatMember value, JsonSerializerOptions options)
        {
            writer.WriteRawValue(value.Serialize());
        }
    }
}
