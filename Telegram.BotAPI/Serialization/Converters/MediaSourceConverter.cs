using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Serialization.Converters;

internal sealed class MediaSourceConverter : JsonConverter<MediaSource>
{
    public override MediaSource Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.String)
        {
            throw new JsonException($"Unexpected token type for MediaSource: {reader.TokenType}");
        }

        return reader.GetString()!;
    }

    public override void Write(Utf8JsonWriter writer, MediaSource value, JsonSerializerOptions options)
    {
        var innerValue = value.Value;
        if (innerValue is string s)
        {
            writer.WriteStringValue(s);
        }
        else
        {
            writer.WriteNullValue();
        }
    }
}
