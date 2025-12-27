using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Extensions;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Serialization.Converters;

public class MaybeInaccessibleMessageConverter : JsonConverter<MaybeInaccessibleMessage>
{
    public override MaybeInaccessibleMessage Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using (var jsonDocument = JsonDocument.ParseValue(ref reader))
        {
            var jsonElement = jsonDocument.RootElement;

            if (jsonElement.GetProperty("date").GetInt32() > 0)
            {
                return jsonElement.GetRawText().Deserialize<Message>();
            }
            else
            {
                return jsonElement.GetRawText().Deserialize<InaccessibleMessage>();
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, MaybeInaccessibleMessage value, JsonSerializerOptions options)
    {
        writer.WriteRawValue(value.Serialize(options.WriteIndented));
    }
}
