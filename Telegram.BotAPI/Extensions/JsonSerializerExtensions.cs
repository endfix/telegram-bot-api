using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Serialization.Converters;

namespace Telegram.BotAPI.Extensions;

public static class JsonSerializerExtensions
{
    private static readonly JsonSerializerOptions _options = new()
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
        return JsonSerializer.Deserialize<T>(json, _options);
    }

    public static string Serialize(this object obj)
    {
        return JsonSerializer.Serialize(obj, _options);
    }

    public static string SerializeWithIndented(this object obj)
    {
        return JsonSerializer.Serialize(obj, new JsonSerializerOptions(_options) { WriteIndented = true, IndentCharacter = ' ', IndentSize = 2 });
    }
}
