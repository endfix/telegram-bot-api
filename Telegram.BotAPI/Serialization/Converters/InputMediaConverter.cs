using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Enums;
using Telegram.BotAPI.Extensions;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Serialization.Converters;

public sealed class InputMediaConverter : JsonConverter<InputMedia>
{
    public override InputMedia Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var innerOptions = new JsonSerializerOptions(options);
        var thisConverter = innerOptions.Converters.FirstOrDefault(c => c is InputMediaConverter);
        if (thisConverter != null)
        {
            innerOptions.Converters.Remove(thisConverter);
        }

        using var jsonDocument = JsonDocument.ParseValue(ref reader);
        var jsonElement = jsonDocument.RootElement;
        var type = jsonElement.GetProperty("type").Deserialize<InputMediaTypes>(options);

        return type switch
        {
            InputMediaTypes.Animation => jsonElement.Deserialize<InputMediaAnimation>(innerOptions)!,
            InputMediaTypes.Document => jsonElement.Deserialize<InputMediaDocument>(innerOptions)!,
            InputMediaTypes.Audio => jsonElement.Deserialize<InputMediaAudio>(innerOptions)!,
            InputMediaTypes.Photo => jsonElement.Deserialize<InputMediaPhoto>(innerOptions)!,
            InputMediaTypes.Video => jsonElement.Deserialize<InputMediaVideo>(innerOptions)!,
            _ => throw new JsonException($"Unknown type: {type}")
        };
    }

    public override void Write(Utf8JsonWriter writer, InputMedia value, JsonSerializerOptions options)
    {
        var innerOptions = new JsonSerializerOptions(options);
        var converter = innerOptions.Converters.FirstOrDefault(c => c is InputMediaConverter);
        if (converter != null)
        {
            innerOptions.Converters.Remove(converter);
        }

        JsonSerializer.Serialize(writer, value, value.GetType(), innerOptions);
    }
}
