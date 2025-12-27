using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Enums;
using Telegram.BotAPI.Extensions;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Serialization.Converters;

public class ReactionTypeConverter : JsonConverter<ReactionType>
{
    public override ReactionType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using (var jsonDocument = JsonDocument.ParseValue(ref reader))
        {
            var jsonElement = jsonDocument.RootElement;
            return Enum.Parse(typeof(ReactionTypes), jsonElement.GetProperty("type").GetString()?.ToUpperInvariant()) switch
            {
                ReactionTypes.Emoji => jsonElement.GetRawText().Deserialize<ReactionTypeEmoji>(),
                ReactionTypes.CustomEmoji => jsonElement.GetRawText().Deserialize<ReactionTypeCustomEmoji>(),
                ReactionTypes.Paid => jsonElement.GetRawText().Deserialize<ReactionTypePaid>(),
                _ => throw new ArgumentOutOfRangeException(jsonElement.GetRawText()),
            };
        }
    }

    public override void Write(Utf8JsonWriter writer, ReactionType value, JsonSerializerOptions options)
    {
        writer.WriteRawValue(value.Serialize(options.WriteIndented));
    }
}
