using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Extensions;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Serialization.Converters;

public class ChatBoostSourceConverter : JsonConverter<ChatBoostSource>
{
    public override ChatBoostSource Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using (var jsonDocument = JsonDocument.ParseValue(ref reader))
        {
            var jsonElement = jsonDocument.RootElement;

            return jsonElement.GetProperty("source").GetString() switch
            {
                ChatBoostSource.Sources.PREMIUM => jsonElement.GetRawText().Deserialize<ChatBoostSourcePremium>(),
                ChatBoostSource.Sources.GIFT_CODE => jsonElement.GetRawText().Deserialize<ChatBoostSourceGiftCode>(),
                ChatBoostSource.Sources.GIVEAWAY => jsonElement.GetRawText().Deserialize<ChatBoostSourceGiveaway>(),
                _ => throw new ArgumentOutOfRangeException(jsonElement.GetRawText()),
            };
        }
    }

    public override void Write(Utf8JsonWriter writer, ChatBoostSource value, JsonSerializerOptions options)
    {
        writer.WriteRawValue(value.Serialize());
    }
}
