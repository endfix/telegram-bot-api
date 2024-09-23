using System.Text.Json;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Serialization.Extensions;
using Telegram.BotAPI.Structs;

namespace Telegram.BotAPI.Serialization.Converters
{
    public class BackgroundTypeConverter : JsonConverter<BackgroundType>
    {
        public override BackgroundType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using var jsonDocument = JsonDocument.ParseValue(ref reader);
            var jsonElement = jsonDocument.RootElement;

            return jsonElement.GetProperty("type").GetString() switch
            {
                BackgroundType.Types.FILL => jsonElement.GetRawText().Deserialize<BackgroundType.FillStruct>(),
                BackgroundType.Types.WALLPAPER => jsonElement.GetRawText().Deserialize<BackgroundType.WallpaperStruct>(),
                BackgroundType.Types.PATTERN => jsonElement.GetRawText().Deserialize<BackgroundType.PatternStruct>(),
                BackgroundType.Types.CHAT_THEME => jsonElement.GetRawText().Deserialize<BackgroundType.ChatThemeStruct>(),
                _ => throw new ArgumentOutOfRangeException(jsonElement.GetRawText())
            };
        }

        public override void Write(Utf8JsonWriter writer, BackgroundType value, JsonSerializerOptions options)
        {
            writer.WriteRawValue(value.Serialize());
        }
    }
}
