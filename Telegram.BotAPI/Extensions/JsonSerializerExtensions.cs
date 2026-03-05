using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Serialization.Converters;

namespace Telegram.BotAPI.Extensions;

public static class JsonSerializerExtensions
{
    public static readonly JsonSerializerOptions Options = new()
    {
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
        Converters = {
            new JsonStringEnumConverter(namingPolicy: JsonNamingPolicy.SnakeCaseLower),
            new BackgroundFillConverter(),
            new BackgroundTypeConverter(),
            new BotCommandScopeConverter(),
            new ChatBoostSourceConverter(),
            new ChatMemberConverter(),
            new InputMediaConverter(),
            new MaybeInaccessibleMessageConverter(),
            new MenuButtonConverter(),
            new MessageOriginConverter(),
            new PaidMediaConverter(),
            new PassportElementErrorConverter(),
            new ReactionTypeConverter()
        }
    };

    public static readonly JsonSerializerOptions IndentedOptions = new JsonSerializerOptions(Options)
    {
        WriteIndented = true,
        IndentCharacter = ' ',
        IndentSize = 4
    };

    public static T? Deserialize<T>(this string json) 
        => string.IsNullOrEmpty(json) ? default : JsonSerializer.Deserialize<T>(json, Options);

    public static string Serialize(this object obj, bool writeIndented = false) 
        => obj is null ? string.Empty : JsonSerializer.Serialize(obj, writeIndented ? IndentedOptions : Options);
}
