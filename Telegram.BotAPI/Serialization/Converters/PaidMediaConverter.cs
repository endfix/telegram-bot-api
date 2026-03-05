using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Enums;
using Telegram.BotAPI.Extensions;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Serialization.Converters;

public sealed class PaidMediaConverter : JsonConverter<PaidMedia>
{
    public override PaidMedia Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var innerOptions = new JsonSerializerOptions(options);
        var thisConverter = innerOptions.Converters.FirstOrDefault(c => c is PaidMediaConverter);
        if (thisConverter != null)
        {
            innerOptions.Converters.Remove(thisConverter);
        }

        using var jsonDocument = JsonDocument.ParseValue(ref reader);
        var jsonElement = jsonDocument.RootElement;
        var type = jsonElement.GetProperty("type").Deserialize<PaidMediaTypes>(options);

        return type switch
        {
            PaidMediaTypes.Photo => jsonElement.Deserialize<PaidMediaPhoto>(innerOptions)!,
            PaidMediaTypes.Video => jsonElement.Deserialize<PaidMediaVideo>(innerOptions)!,
            PaidMediaTypes.Preview => jsonElement.Deserialize<PaidMediaPreview>(innerOptions)!,
            _ => throw new JsonException($"Unknown type: {type}")
        };
    }

    public override void Write(Utf8JsonWriter writer, PaidMedia value, JsonSerializerOptions options)
    {
        var innerOptions = new JsonSerializerOptions(options);
        var converter = innerOptions.Converters.FirstOrDefault(c => c is PaidMediaConverter);
        if (converter != null)
        {
            innerOptions.Converters.Remove(converter);
        }

        JsonSerializer.Serialize(writer, value, value.GetType(), innerOptions);
    }
}
