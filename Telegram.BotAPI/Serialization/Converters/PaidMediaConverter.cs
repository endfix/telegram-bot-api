using System.Text.Json;
using System;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Extensions;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Serialization.Converters;

public sealed class PaidMediaConverter : JsonConverter<PaidMedia>
{
    public override PaidMedia Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using (var jsonDocument = JsonDocument.ParseValue(ref reader))
        {
            var jsonElement = jsonDocument.RootElement;

            return jsonElement.GetProperty("type").GetString() switch
            {
                PaidMedia.Types.PHOTO => jsonElement.GetRawText().Deserialize<PaidMediaPhoto>(),
                PaidMedia.Types.VIDEO => jsonElement.GetRawText().Deserialize<PaidMediaVideo>(),
                PaidMedia.Types.PREVIEW => jsonElement.GetRawText().Deserialize<PaidMediaPreview>(),
                _ => throw new ArgumentOutOfRangeException(jsonElement.GetRawText()),
            };
        }
    }

    public override void Write(Utf8JsonWriter writer, PaidMedia value, JsonSerializerOptions options)
    {
        writer.WriteRawValue(value.Serialize());
    }
}
