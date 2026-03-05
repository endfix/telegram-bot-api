using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Enums;
using Telegram.BotAPI.Extensions;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Serialization.Converters;

public sealed class ChatMemberConverter : JsonConverter<ChatMember>
{
    public override ChatMember Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var innerOptions = new JsonSerializerOptions(options);
        var thisConverter = innerOptions.Converters.FirstOrDefault(c => c is ChatMemberConverter);
        if (thisConverter != null)
        {
            innerOptions.Converters.Remove(thisConverter);
        }

        using var jsonDocument = JsonDocument.ParseValue(ref reader);
        var jsonElement = jsonDocument.RootElement;
        var status = jsonElement.GetProperty("status").Deserialize<ChatMemberStatus>(options);

        return status switch
        {
            ChatMemberStatus.Creator => jsonElement.Deserialize<ChatMemberOwner>(innerOptions)!,
            ChatMemberStatus.Administrator => jsonElement.Deserialize<ChatMemberAdministrator>(innerOptions)!,
            ChatMemberStatus.Member => jsonElement.Deserialize<ChatMemberMember>(innerOptions)!,
            ChatMemberStatus.Restricted => jsonElement.Deserialize<ChatMemberRestricted>(innerOptions)!,
            ChatMemberStatus.Left => jsonElement.Deserialize<ChatMemberLeft>(innerOptions)!,
            ChatMemberStatus.Kicked => jsonElement.Deserialize<ChatMemberBanned>(innerOptions)!,
            _ => throw new JsonException($"Unknown type: {status}")
        };
    }

    public override void Write(Utf8JsonWriter writer, ChatMember value, JsonSerializerOptions options)
    {
        var innerOptions = new JsonSerializerOptions(options);
        var converter = innerOptions.Converters.FirstOrDefault(c => c is ChatMemberConverter);
        if (converter != null)
        {
            innerOptions.Converters.Remove(converter);
        }

        JsonSerializer.Serialize(writer, value, value.GetType(), innerOptions);
    }
}
