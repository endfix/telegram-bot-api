using System.Text.Encodings.Web;
using System.Text.Json;
using Telegram.BotAPI.Serialization.Converters;

namespace Telegram.BotAPI.Serialization.Extensions
{
    public static class JsonSerializerExtensions
    {
        private static readonly JsonSerializerOptions _options = new()
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            //PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = new SnakeCaseNamingPolicy(),
            Converters = {
                new BackgroundFillConverter(),
                new BackgroundTypeConverter(),
                new BotCommandScopeConverter(),
                new ChatBoostSourceConverter(),
                new ChatMemberConverter(),
                new InputMediaConverter(),
                new MenuButtonConverter(),
                new MessageOriginConverter(),
                new ReactionTypeConverter(),
            },
            WriteIndented = true
        };

        public static T Deserialize<T>(this string json, JsonSerializerOptions options = null)
        {
            return JsonSerializer.Deserialize<T>(json, options ?? _options);
        }

        public static string Serialize(this object obj, JsonSerializerOptions options = null)
        {
            return JsonSerializer.Serialize(obj, options ?? _options);
        }
    }
}
