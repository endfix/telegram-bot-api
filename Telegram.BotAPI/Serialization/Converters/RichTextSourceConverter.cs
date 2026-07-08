using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Serialization.Converters;

public sealed class RichTextSourceConverter : JsonConverter<RichTextSource>
{
    public override RichTextSource Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            return reader.GetString()!;
        }

        return JsonSerializer.Deserialize<RichText>(ref reader, options)!;
    }

    public override void Write(Utf8JsonWriter writer, RichTextSource value, JsonSerializerOptions options)
    {
        var innerValue = value.Value;
        if (innerValue is null)
        {
            writer.WriteNullValue();
            return;
        }

        JsonSerializer.Serialize(writer, innerValue, innerValue.GetType(), options);
    }
}
