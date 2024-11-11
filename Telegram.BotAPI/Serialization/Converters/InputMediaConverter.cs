using System.Text.Json;
using System.Text.Json.Serialization;
using System;
using Telegram.BotAPI.Extensions;
using Telegram.BotAPI.Types.AvailableTypes;

namespace Telegram.BotAPI.Serialization.Converters;

public class InputMediaConverter : JsonConverter<InputMedia>
{
    public override InputMedia Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using (var jsonDocument = JsonDocument.ParseValue(ref reader))
        {
            var jsonElement = jsonDocument.RootElement;

            return jsonElement.GetProperty("type").GetString() switch
            {
                InputMedia.Types.ANIMATION => jsonElement.GetRawText().Deserialize<InputMediaAnimation>(),
                InputMedia.Types.DOCUMENT => jsonElement.GetRawText().Deserialize<InputMediaDocument>(),
                InputMedia.Types.AUDIO => jsonElement.GetRawText().Deserialize<InputMediaAudio>(),
                InputMedia.Types.PHOTO => jsonElement.GetRawText().Deserialize<InputMediaPhoto>(),
                InputMedia.Types.VIDEO => jsonElement.GetRawText().Deserialize<InputMediaVideo>(),
                _ => throw new ArgumentOutOfRangeException(jsonElement.GetRawText()),
            };
        }
    }

    public override void Write(Utf8JsonWriter writer, InputMedia value, JsonSerializerOptions options)
    {
        writer.WriteRawValue(value.Serialize());
    }
}
