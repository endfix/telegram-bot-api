using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Enums;
using Telegram.BotAPI.Extensions;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Serialization.Converters;

internal sealed class ChatMemberConverter : JsonConverter<ChatMember>
{
    public override ChatMember? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var jsonDocument = JsonDocument.ParseValue(ref reader);
        var root = jsonDocument.RootElement;

        if (!root.TryGetProperty("status", out var statusProperty) || !statusProperty.TryGetEnum<ChatMemberStatus>(options, out var status))
        {
            throw new JsonException("Missing discriminator 'status' in ChatMember");
        }

        return status switch
        {
            ChatMemberStatus.Creator => root.Deserialize<ChatMemberOwner>(options),
            ChatMemberStatus.Administrator => root.Deserialize<ChatMemberAdministrator>(options),
            ChatMemberStatus.Member => root.Deserialize<ChatMemberMember>(options),
            ChatMemberStatus.Restricted => root.Deserialize<ChatMemberRestricted>(options),
            ChatMemberStatus.Left => root.Deserialize<ChatMemberLeft>(options),
            ChatMemberStatus.Kicked => root.Deserialize<ChatMemberBanned>(options),
            _ => throw new JsonException($"Unknown ChatMember status: {status}")
        };
    }

    public override void Write(Utf8JsonWriter writer, ChatMember value, JsonSerializerOptions options)
    {
        if (value is null)
        {
            writer.WriteNullValue();
            return;
        }

        JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
}
