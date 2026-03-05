using System;
using System.Linq;
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
        var innerOptions = new JsonSerializerOptions(options);
        var thisConverter = innerOptions.Converters.FirstOrDefault(c => c is BotCommandScopeConverter);
        if (thisConverter != null)
        {
            innerOptions.Converters.Remove(thisConverter);
        }

        using var jsonDocument = JsonDocument.ParseValue(ref reader);
        var jsonElement = jsonDocument.RootElement;
        var type = jsonElement.GetProperty("type").Deserialize<BotCommandScopeTypes>(options);

        return type switch
        {
            BotCommandScopeTypes.Default => jsonElement.Deserialize<BotCommandScopeDefault>(innerOptions)!,
            BotCommandScopeTypes.AllPrivateChats => jsonElement.Deserialize<BotCommandScopeAllPrivateChats>(innerOptions)!,
            BotCommandScopeTypes.AllGroupChats => jsonElement.Deserialize<BotCommandScopeAllGroupChats>(innerOptions)!,
            BotCommandScopeTypes.AllChatAdministrators => jsonElement.Deserialize<BotCommandScopeAllChatAdministrators>(innerOptions)!,
            BotCommandScopeTypes.Chat => jsonElement.Deserialize<BotCommandScopeChat>(innerOptions)!,
            BotCommandScopeTypes.ChatAdministrators => jsonElement.Deserialize<BotCommandScopeChatAdministrators>(innerOptions)!,
            BotCommandScopeTypes.ChatMember => jsonElement.Deserialize<BotCommandScopeChatMember>(innerOptions)!,
            _ => throw new JsonException($"Unknown type: {type}")
        };
    }

    public override void Write(Utf8JsonWriter writer, BotCommandScope value, JsonSerializerOptions options)
    {
        var innerOptions = new JsonSerializerOptions(options);
        var converter = innerOptions.Converters.FirstOrDefault(c => c is BotCommandScopeConverter);
        if (converter != null)
        {
            innerOptions.Converters.Remove(converter);
        }

        JsonSerializer.Serialize(writer, value, value.GetType(), innerOptions);
    }
}
