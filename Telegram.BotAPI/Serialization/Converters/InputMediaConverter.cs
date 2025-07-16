using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Extensions;
using Telegram.BotAPI.Types;
using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Serialization.Converters;

public class InputMediaConverter : JsonConverter<InputMedia>
{
    public override InputMedia Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using (var jsonDocument = JsonDocument.ParseValue(ref reader))
        {
            var jsonElement = jsonDocument.RootElement;
            return Enum.Parse(typeof(InputMediaTypes), jsonElement.GetProperty("type").GetString()?.ToUpperInvariant()) switch
            {
                InputMediaTypes.Animation => jsonElement.GetRawText().Deserialize<InputMediaAnimation>(),
                InputMediaTypes.Document => jsonElement.GetRawText().Deserialize<InputMediaDocument>(),
                InputMediaTypes.Audio => jsonElement.GetRawText().Deserialize<InputMediaAudio>(),
                InputMediaTypes.Photo => jsonElement.GetRawText().Deserialize<InputMediaPhoto>(),
                InputMediaTypes.Video => jsonElement.GetRawText().Deserialize<InputMediaVideo>(),
                _ => throw new ArgumentOutOfRangeException(jsonElement.GetRawText()),
            };
        }
    }

    public override void Write(Utf8JsonWriter writer, InputMedia value, JsonSerializerOptions options)
    {
        writer.WriteRawValue(options.WriteIndented ? value.SerializeWithIndented() : value.Serialize());
    }
}
