using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Serialization.Converters;

internal sealed class ChatIdSourceConverter : JsonConverter<ChatIdSource>
{
    public override ChatIdSource Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Number)
        {
            return reader.GetInt64();
        }

        if (reader.TokenType == JsonTokenType.String)
        {
            var value = reader.GetString();
            if (long.TryParse(value, out var id))
            {
                return id;
            }

            if (value is null)
            {
                throw new JsonException(nameof(value));
            }

            return value;
        }

        throw new JsonException($"Unexpected token type for ChatIdSource: {reader.TokenType}");
    }

    public override void Write(Utf8JsonWriter writer, ChatIdSource value, JsonSerializerOptions options)
    {
        var innerValue = value.Value;
        if (innerValue is long id)
        {
            writer.WriteNumberValue(id);
        }
        else if (innerValue is string username)
        {
            writer.WriteStringValue(username);
        }
        else
        {
            throw new JsonException($"Unsupported type for ChatIdSource: {innerValue.GetType().Name}");
        }
    }
}
