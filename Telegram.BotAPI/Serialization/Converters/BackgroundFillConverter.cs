using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Enums;
using Telegram.BotAPI.Extensions;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Serialization.Converters;

public sealed class BackgroundFillConverter : JsonConverter<BackgroundFill>
{
    public override BackgroundFill Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var innerOptions = new JsonSerializerOptions(options);
        var thisConverter = innerOptions.Converters.FirstOrDefault(c => c is BackgroundFillConverter);
        if (thisConverter != null)
        {
            innerOptions.Converters.Remove(thisConverter);
        }

        using var jsonDocument = JsonDocument.ParseValue(ref reader);
        var jsonElement = jsonDocument.RootElement;
        var type = jsonElement.GetProperty("type").Deserialize<BackgroundFillTypes>(options);

        return type switch
        {
            BackgroundFillTypes.Solid => jsonElement.Deserialize<BackgroundFillSolid>(innerOptions)!,
            BackgroundFillTypes.Gradient => jsonElement.Deserialize<BackgroundFillGradient>(innerOptions)!,
            BackgroundFillTypes.FreeformGradient => jsonElement.Deserialize<BackgroundFillFreeformGradient>(innerOptions)!,
            _ => throw new JsonException($"Unknown type: {type}")
        };
    }

    public override void Write(Utf8JsonWriter writer, BackgroundFill value, JsonSerializerOptions options)
    {
        var innerOptions = new JsonSerializerOptions(options);
        var converter = innerOptions.Converters.FirstOrDefault(c => c is BackgroundFillConverter);
        if (converter != null)
        {
            innerOptions.Converters.Remove(converter);
        }

        JsonSerializer.Serialize(writer, value, value.GetType(), innerOptions);
    }
}
