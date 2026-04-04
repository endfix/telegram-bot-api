using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Serialization.Converters;

public class MaybeInaccessibleMessageConverter : JsonConverter<MaybeInaccessibleMessage>
{
    public override MaybeInaccessibleMessage? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;

        if (!root.TryGetProperty("date", out var date))
        {
            throw new JsonException("Property 'date' not found in MaybeInaccessibleMessage.");
        }

        return date.GetInt64() > 0
            ? root.Deserialize<Message>(options)
            : root.Deserialize<InaccessibleMessage>(options);
    }

    public override void Write(Utf8JsonWriter writer, MaybeInaccessibleMessage value, JsonSerializerOptions options)
    {
        if (value is null)
        {
            writer.WriteNullValue();
            return;
        }

        JsonSerializer.Serialize(writer, (object)value, options);
    }
}
