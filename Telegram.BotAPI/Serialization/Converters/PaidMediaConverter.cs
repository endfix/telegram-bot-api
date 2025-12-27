using System.Text.Json;
using System;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Extensions;
using Telegram.BotAPI.Types;
using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Serialization.Converters;

public sealed class PaidMediaConverter : JsonConverter<PaidMedia>
{
    public override PaidMedia Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using (var jsonDocument = JsonDocument.ParseValue(ref reader))
        {
            var jsonElement = jsonDocument.RootElement;
            return Enum.Parse(typeof(PaidMediaTypes), jsonElement.GetProperty("type").GetString()?.ToUpperInvariant()) switch
            {
                PaidMediaTypes.Photo => jsonElement.GetRawText().Deserialize<PaidMediaPhoto>(),
                PaidMediaTypes.Video => jsonElement.GetRawText().Deserialize<PaidMediaVideo>(),
                PaidMediaTypes.Preview => jsonElement.GetRawText().Deserialize<PaidMediaPreview>(),
                _ => throw new ArgumentOutOfRangeException(jsonElement.GetRawText()),
            };
        }
    }

    public override void Write(Utf8JsonWriter writer, PaidMedia value, JsonSerializerOptions options)
    {
        writer.WriteRawValue(value.Serialize(options.WriteIndented));
    }
}
