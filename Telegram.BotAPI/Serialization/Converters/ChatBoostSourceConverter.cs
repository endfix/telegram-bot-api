using System.Text.Json;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Serialization.Extensions;
using Telegram.BotAPI.Structs;

namespace Telegram.BotAPI.Serialization.Converters
{
    public class ChatBoostSourceConverter : JsonConverter<ChatBoostSource>
    {
        public override ChatBoostSource Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using var jsonDocument = JsonDocument.ParseValue(ref reader);
            var jsonElement = jsonDocument.RootElement;

            return jsonElement.GetProperty("source").GetString() switch
            {
                ChatBoostSource.Types.PREMIUM => jsonElement.GetRawText().Deserialize<ChatBoostSource.PremiumStruct>(),
                ChatBoostSource.Types.GIFT_CODE => jsonElement.GetRawText().Deserialize<ChatBoostSource.GiftCodeStruct>(),
                ChatBoostSource.Types.GIVEAWAY => jsonElement.GetRawText().Deserialize<ChatBoostSource.GiveawayStruct>(),
                _ => throw new ArgumentOutOfRangeException(jsonElement.GetRawText())
            };
        }

        public override void Write(Utf8JsonWriter writer, ChatBoostSource value, JsonSerializerOptions options)
        {
            writer.WriteRawValue(value.Serialize());
        }
    }
}
