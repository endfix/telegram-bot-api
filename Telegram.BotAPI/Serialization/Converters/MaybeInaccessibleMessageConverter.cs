using System;
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

        bool dateFound = false;
        int dateValue = 0;

        while (readerCopy.Read())
        {
            if (readerCopy.TokenType == JsonTokenType.PropertyName && readerCopy.GetString() == "date")
            {
                readerCopy.Read();
                dateValue = readerCopy.GetInt32();
                dateFound = true;
                break;
            }
        }

        if (!dateFound)
        {
            throw new JsonException("Required property 'date' not found.");
        }

        if (dateValue > 0)
        {
            return (MaybeInaccessibleMessage)JsonSerializer.Deserialize(ref reader, typeof(Message), options)!;
        }
        else
        {
            return (MaybeInaccessibleMessage)JsonSerializer.Deserialize(ref reader, typeof(InaccessibleMessage), options)!;
        }
    }

    public override void Write(Utf8JsonWriter writer, MaybeInaccessibleMessage value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
}
