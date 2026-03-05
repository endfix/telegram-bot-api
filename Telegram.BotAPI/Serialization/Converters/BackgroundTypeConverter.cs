using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Enums;
using Telegram.BotAPI.Extensions;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Serialization.Converters;

public sealed class BackgroundTypeConverter : JsonConverter<BackgroundType>
{
    public override BackgroundType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var innerOptions = new JsonSerializerOptions(options);
        var thisConverter = innerOptions.Converters.FirstOrDefault(c => c is BackgroundTypeConverter);
        if (thisConverter != null)
        {
            innerOptions.Converters.Remove(thisConverter);
        }

        using var jsonDocument = JsonDocument.ParseValue(ref reader);
        var jsonElement = jsonDocument.RootElement;
        var type = jsonElement.GetProperty("type").Deserialize<BackgroundTypes>(options);

        return type switch
        {
            BackgroundTypes.Fill => jsonElement.Deserialize<BackgroundTypeFill>(innerOptions)!,
            BackgroundTypes.Wallpaper => jsonElement.Deserialize<BackgroundTypeWallpaper>(innerOptions)!,
            BackgroundTypes.Pattern => jsonElement.Deserialize<BackgroundTypePattern>(innerOptions)!,
            BackgroundTypes.ChatTheme => jsonElement.Deserialize<BackgroundTypeChatTheme>(innerOptions)!,
            _ => throw new JsonException($"Unknown type: {type}")
        };
    }

    public override void Write(Utf8JsonWriter writer, BackgroundType value, JsonSerializerOptions options)
    {
        var innerOptions = new JsonSerializerOptions(options);
        var converter = innerOptions.Converters.FirstOrDefault(c => c is BackgroundTypeConverter);
        if (converter != null)
        {
            innerOptions.Converters.Remove(converter);
        }

        JsonSerializer.Serialize(writer, value, value.GetType(), innerOptions);
    }
}
