using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Serialization.Converters;

namespace Telegram.BotAPI.Extensions;

public static class JsonSerializerExtensions
{
    public static JsonSerializerOptions OPTIONS => new()
    {
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        //PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
        Converters = {
            new JsonStringEnumConverter(namingPolicy: JsonNamingPolicy.SnakeCaseLower),
            new BackgroundFillConverter(),
            new BackgroundTypeConverter(),
            new BotCommandScopeConverter(),
            new ChatBoostSourceConverter(),
            new PassportElementErrorConverter(),
            new ChatMemberConverter(),
            new InputMediaConverter(),
            new MessageOriginConverter(),
            new PaidMediaConverter(),
            new ReactionTypeConverter(),
            new MenuButtonConverter(),
            new MaybeInaccessibleMessageConverter()
        },
        //PreferredObjectCreationHandling = JsonObjectCreationHandling.Populate,
        //UnmappedMemberHandling = JsonUnmappedMemberHandling.Disallow
    };

    public static T Deserialize<T>(this string json)
    {
        return JsonSerializer.Deserialize<T>(json, OPTIONS);
    }

    public static string Serialize(this object obj)
    {
        return JsonSerializer.Serialize(obj, OPTIONS);
    }

    public static string SerializeWithIndented(this object obj)
    {
        return JsonSerializer.Serialize(obj, new JsonSerializerOptions(OPTIONS) { WriteIndented = true, IndentCharacter = ' ', IndentSize = 2 });
    }
}
