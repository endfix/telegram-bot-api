using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Extensions;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Serialization.Converters;

public sealed class ChatMemberConverter : JsonConverter<ChatMember>
{
    public override ChatMember? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var jsonDocument = JsonDocument.ParseValue(ref reader);
        var root = jsonDocument.RootElement;

        if (!root.TryGetProperty("status", out var status))
        {
            throw new JsonException("Missing discriminator 'status' in ChatMember");
        }

        return status.GetString() switch
        {
            "creator" => root.Deserialize<ChatMemberOwner>(options),
            "administrator" => root.Deserialize<ChatMemberAdministrator>(options),
            "member" => root.Deserialize<ChatMemberMember>(options),
            "restricted" => root.Deserialize<ChatMemberRestricted>(options),
            "left" => root.Deserialize<ChatMemberLeft>(options),
            "kicked" => root.Deserialize<ChatMemberBanned>(options),
            _ => throw new JsonException($"Unknown ChatMember status: {status}")
        };
    }

    public override void Write(Utf8JsonWriter writer, ChatMember value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
}
