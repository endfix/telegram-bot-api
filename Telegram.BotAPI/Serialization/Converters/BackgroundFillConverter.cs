using System.Text.Json;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Serialization.Extensions;
using Telegram.BotAPI.Structs;

namespace Telegram.BotAPI.Serialization.Converters
{
    public class BackgroundFillConverter : JsonConverter<BackgroundFill>
    {
        public override BackgroundFill Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using var jsonDocument = JsonDocument.ParseValue(ref reader);
            var jsonElement = jsonDocument.RootElement;

            return jsonElement.GetProperty("type").GetString() switch
            {
                BackgroundFill.Types.SOLID => jsonElement.GetRawText().Deserialize<BackgroundFill.SolidStruct>(),
                BackgroundFill.Types.GRADIENT => jsonElement.GetRawText().Deserialize<BackgroundFill.GradientStruct>(),
                BackgroundFill.Types.FREEFORM_GRADIENT => jsonElement.GetRawText().Deserialize<BackgroundFill.FreeformGradientStruct>(),
                _ => throw new ArgumentOutOfRangeException(jsonElement.GetRawText())
            };
        }

        public override void Write(Utf8JsonWriter writer, BackgroundFill value, JsonSerializerOptions options)
        {
            writer.WriteRawValue(value.Serialize());
        }
    }
}
