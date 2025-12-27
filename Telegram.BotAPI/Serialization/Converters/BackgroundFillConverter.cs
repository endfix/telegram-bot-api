using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Enums;
using Telegram.BotAPI.Extensions;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Serialization.Converters;

public class BackgroundFillConverter : JsonConverter<BackgroundFill>
{
    public override BackgroundFill Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using (var jsonDocument = JsonDocument.ParseValue(ref reader))
        {
            var jsonElement = jsonDocument.RootElement;
            return Enum.Parse(typeof(BackgroundFillTypes), jsonElement.GetProperty("type").GetString()?.ToUpperInvariant()) switch
            {
                BackgroundFillTypes.Solid => jsonElement.GetRawText().Deserialize<BackgroundFillSolid>(),
                BackgroundFillTypes.Gradient => jsonElement.GetRawText().Deserialize<BackgroundFillGradient>(),
                BackgroundFillTypes.FreeformGradient => jsonElement.GetRawText().Deserialize<BackgroundFillFreeformGradient>(),
                _ => throw new ArgumentOutOfRangeException(jsonElement.GetRawText()),
            };
        }
    }

    public override void Write(Utf8JsonWriter writer, BackgroundFill value, JsonSerializerOptions options)
    {
        writer.WriteRawValue(value.Serialize(options.WriteIndented));
    }
}
