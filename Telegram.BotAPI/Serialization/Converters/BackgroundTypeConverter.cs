using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Extensions;
using Telegram.BotAPI.Types.AvailableTypes;

namespace Telegram.BotAPI.Serialization.Converters;

public class BackgroundTypeConverter : JsonConverter<BackgroundType>
{
    public override BackgroundType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using (var jsonDocument = JsonDocument.ParseValue(ref reader))
        {
            var jsonElement = jsonDocument.RootElement;

            return jsonElement.GetProperty("type").GetString() switch
            {
                BackgroundType.Types.FILL => jsonElement.GetRawText().Deserialize<BackgroundTypeFill>(),
                BackgroundType.Types.WALLPAPER => jsonElement.GetRawText().Deserialize<BackgroundTypeWallpaper>(),
                BackgroundType.Types.PATTERN => jsonElement.GetRawText().Deserialize<BackgroundTypePattern>(),
                BackgroundType.Types.CHAT_THEME => jsonElement.GetRawText().Deserialize<BackgroundTypeChatTheme>(),
                _ => throw new ArgumentOutOfRangeException(jsonElement.GetRawText()),
            };
        }
    }

    public override void Write(Utf8JsonWriter writer, BackgroundType value, JsonSerializerOptions options)
    {
        writer.WriteRawValue(value.Serialize());
    }
}
