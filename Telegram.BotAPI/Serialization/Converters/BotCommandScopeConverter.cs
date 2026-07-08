using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Enums;
using Telegram.BotAPI.Extensions;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Serialization.Converters;

public sealed class BotCommandScopeConverter : JsonConverter<BotCommandScope>
{
    public override BotCommandScope Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var jsonDocument = JsonDocument.ParseValue(ref reader);
        var root = jsonDocument.RootElement;

        if (!root.TryGetProperty("type", out var typeProperty) || !typeProperty.TryGetEnum<BotCommandScopeType>(options, out var type))
        {
            throw new JsonException("Missing discriminator 'type' in BotCommandScope");
        }

        return type switch
        {
            BotCommandScopeType.Default => root.Deserialize<BotCommandScopeDefault>(options)!,
            BotCommandScopeType.AllPrivateChats => root.Deserialize<BotCommandScopeAllPrivateChats>(options)!,
            BotCommandScopeType.AllGroupChats => root.Deserialize<BotCommandScopeAllGroupChats>(options)!,
            BotCommandScopeType.AllChatAdministrators => root.Deserialize<BotCommandScopeAllChatAdministrators>(options)!,
            BotCommandScopeType.Chat => root.Deserialize<BotCommandScopeChat>(options)!,
            BotCommandScopeType.ChatAdministrators => root.Deserialize<BotCommandScopeChatAdministrators>(options)!,
            BotCommandScopeType.ChatMember => root.Deserialize<BotCommandScopeChatMember>(options)!,
            _ => throw new JsonException($"Unknown BotCommandScope type: {type}")
        };
    }

    public override void Write(Utf8JsonWriter writer, BotCommandScope value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
}
