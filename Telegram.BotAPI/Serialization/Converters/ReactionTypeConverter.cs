using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Extensions;
using Telegram.BotAPI.Types.AvailableTypes;

namespace Telegram.BotAPI.Serialization.Converters;

public class ReactionTypeConverter : JsonConverter<ReactionType>
{
    public override ReactionType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using (var jsonDocument = JsonDocument.ParseValue(ref reader))
        {
            var jsonElement = jsonDocument.RootElement;

            return jsonElement.GetProperty("type").GetString() switch
            {
                ReactionType.Types.EMOJI => jsonElement.GetRawText().Deserialize<ReactionTypeEmoji>(),
                ReactionType.Types.CUSTOM_EMOJI => jsonElement.GetRawText().Deserialize<ReactionTypeCustomEmoji>(),
                ReactionType.Types.PAID => jsonElement.GetRawText().Deserialize<ReactionTypePaid>(),
                _ => throw new ArgumentOutOfRangeException(jsonElement.GetRawText()),
            };
        }
    }

    public override void Write(Utf8JsonWriter writer, ReactionType value, JsonSerializerOptions options)
    {
        writer.WriteRawValue(value.Serialize());
    }
}
