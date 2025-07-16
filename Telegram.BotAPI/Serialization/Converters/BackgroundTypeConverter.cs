using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Enums;
using Telegram.BotAPI.Extensions;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Serialization.Converters;

public class BackgroundTypeConverter : JsonConverter<BackgroundType>
{
    public override BackgroundType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using (var jsonDocument = JsonDocument.ParseValue(ref reader))
        {
            var jsonElement = jsonDocument.RootElement;
            return Enum.Parse(typeof(BackgroundTypes), jsonElement.GetProperty("type").GetString()?.ToUpperInvariant()) switch
            {
                BackgroundTypes.Fill => jsonElement.GetRawText().Deserialize<BackgroundTypeFill>(),
                BackgroundTypes.Wallpaper => jsonElement.GetRawText().Deserialize<BackgroundTypeWallpaper>(),
                BackgroundTypes.Pattern => jsonElement.GetRawText().Deserialize<BackgroundTypePattern>(),
                BackgroundTypes.ChatTheme => jsonElement.GetRawText().Deserialize<BackgroundTypeChatTheme>(),
                _ => throw new ArgumentOutOfRangeException(jsonElement.GetRawText()),
            };
        }
    }

    public override void Write(Utf8JsonWriter writer, BackgroundType value, JsonSerializerOptions options)
    {
        writer.WriteRawValue(options.WriteIndented ? value.SerializeWithIndented() : value.Serialize());
    }
}
