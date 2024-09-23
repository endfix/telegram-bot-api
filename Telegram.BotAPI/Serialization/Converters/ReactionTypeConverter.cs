using System.Text.Json;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Serialization.Extensions;
using Telegram.BotAPI.Structs;

namespace Telegram.BotAPI.Serialization.Converters
{
    public class ReactionTypeConverter : JsonConverter<ReactionType>
    {
        public override ReactionType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using var jsonDocument = JsonDocument.ParseValue(ref reader);
            var jsonElement = jsonDocument.RootElement;

            return jsonElement.GetProperty("type").GetString() switch
            {
                ReactionType.Types.EMOJI => jsonElement.GetRawText().Deserialize<ReactionType.EmojiStruct>(),
                ReactionType.Types.CUSTOM_EMOJI => jsonElement.GetRawText().Deserialize<ReactionType.CustomEmojiStruct>(),
                ReactionType.Types.PAID => jsonElement.GetRawText().Deserialize<ReactionType.PaidStruct>(),
                _ => throw new ArgumentOutOfRangeException(jsonElement.GetRawText())
            };
        }

        public override void Write(Utf8JsonWriter writer, ReactionType value, JsonSerializerOptions options)
        {
            throw new NotImplementedException("ReactionTypeConverter::Write");
        }
    }
}
