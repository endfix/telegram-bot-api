using System.Text.Json;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Structs;
using Telegram.BotAPI.Serialization.Extensions;

namespace Telegram.BotAPI.Serialization.Converters
{
    public class InputMediaConverter : JsonConverter<InputMedia>
    {
        public override InputMedia Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using var jsonDocument = JsonDocument.ParseValue(ref reader);
            var jsonElement = jsonDocument.RootElement;

            return jsonElement.GetProperty("type").GetString() switch
            {
                InputMedia.Types.ANIMATION => jsonElement.GetRawText().Deserialize<InputMedia.AnimationStruct>(),
                InputMedia.Types.DOCUMENT => jsonElement.GetRawText().Deserialize<InputMedia.DocumentStruct>(),
                InputMedia.Types.AUDIO => jsonElement.GetRawText().Deserialize<InputMedia.AudioStruct>(),
                InputMedia.Types.PHOTO => jsonElement.GetRawText().Deserialize<InputMedia.PhotoStruct>(),
                InputMedia.Types.VIDEO => jsonElement.GetRawText().Deserialize<InputMedia.VideoStruct>(),
                _ => throw new ArgumentOutOfRangeException(jsonElement.GetRawText())
            };
        }

        public override void Write(Utf8JsonWriter writer, InputMedia value, JsonSerializerOptions options)
        {
            writer.WriteRawValue(value.Serialize());
        }
    }
}
