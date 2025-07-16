using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Enums;
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
            return Enum.Parse(typeof(ChatBoostSources), jsonElement.GetProperty("source").GetString()?.ToUpperInvariant()) switch
            {
                ChatBoostSources.Premium => jsonElement.GetRawText().Deserialize<ChatBoostSourcePremium>(),
                ChatBoostSources.GiftCode => jsonElement.GetRawText().Deserialize<ChatBoostSourceGiftCode>(),
                ChatBoostSources.Giveaway => jsonElement.GetRawText().Deserialize<ChatBoostSourceGiveaway>(),
                _ => throw new ArgumentOutOfRangeException(jsonElement.GetRawText()),
            };
        }
    }

    public override void Write(Utf8JsonWriter writer, ChatBoostSource value, JsonSerializerOptions options)
    {
        writer.WriteRawValue(options.WriteIndented ? value.SerializeWithIndented() : value.Serialize());
    }
}
