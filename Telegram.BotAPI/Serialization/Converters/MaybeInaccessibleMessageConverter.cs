using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Serialization.Converters;

public class MaybeInaccessibleMessageConverter : JsonConverter<MaybeInaccessibleMessage>
{
    public override MaybeInaccessibleMessage Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var readerCopy = reader;
        if (readerCopy.TokenType != JsonTokenType.StartObject)
        {
            throw new JsonException("Expected StartObject token.");
        }

        var dateValue = 0;
        var dateFound = false;

        while (readerCopy.Read() && readerCopy.TokenType != JsonTokenType.EndObject)
        {
            if (readerCopy.TokenType == JsonTokenType.PropertyName && readerCopy.ValueTextEquals("date"))
            {
                readerCopy.Read();
                dateValue = readerCopy.GetInt32();
                dateFound = true;
                break;
            }
            readerCopy.Skip();
        }

        if (!dateFound)
        {
            throw new JsonException("Required property 'date' not found.");
        }

        return dateValue > 0
            ? (Message)JsonSerializer.Deserialize(ref reader, typeof(Message), options)!
            : (InaccessibleMessage)JsonSerializer.Deserialize(ref reader, typeof(InaccessibleMessage), options)!;
    }

    public override void Write(Utf8JsonWriter writer, MaybeInaccessibleMessage value, JsonSerializerOptions options)
    {
        var innerOptions = new JsonSerializerOptions(options);
        var converter = innerOptions.Converters.FirstOrDefault(c => c is MaybeInaccessibleMessageConverter);
        if (converter != null)
        {
            innerOptions.Converters.Remove(converter);
        }

        JsonSerializer.Serialize(writer, value, value.GetType(), innerOptions);
    }
}
