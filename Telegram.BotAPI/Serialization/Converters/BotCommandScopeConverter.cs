using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Extensions;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Serialization.Converters;

public sealed class BotCommandScopeConverter : JsonConverter<BotCommandScope>
{
    public override BotCommandScope Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var jsonDocument = JsonDocument.ParseValue(ref reader);
        var root = jsonDocument.RootElement;

        if (!root.TryGetProperty("type", out var type))
        {
            throw new JsonException("Missing discriminator 'type' in BotCommandScope");
        }

        return type.GetString() switch
        {
            "default" => root.Deserialize<BotCommandScopeDefault>(options)!,
            "all_private_chats" => root.Deserialize<BotCommandScopeAllPrivateChats>(options)!,
            "all_group_chats" => root.Deserialize<BotCommandScopeAllGroupChats>(options)!,
            "all_chat_administrators" => root.Deserialize<BotCommandScopeAllChatAdministrators>(options)!,
            "chat" => root.Deserialize<BotCommandScopeChat>(options)!,
            "chat_administrators" => root.Deserialize<BotCommandScopeChatAdministrators>(options)!,
            "chat_member" => root.Deserialize<BotCommandScopeChatMember>(options)!,
            _ => throw new JsonException($"Unknown BotCommandScope type: {type}")
        };
    }

    public override void Write(Utf8JsonWriter writer, BotCommandScope value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
}
