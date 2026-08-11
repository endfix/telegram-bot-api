using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Serialization.Converters;

internal sealed class CoverSourceConverter : JsonConverter<CoverSource>
{
    public override CoverSource Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        => reader.GetString() ?? throw new JsonException("Cover source must be a string.");

    public override void Write(Utf8JsonWriter writer, CoverSource value, JsonSerializerOptions options)
    {
        if (value.Value is string source)
        {
            writer.WriteStringValue(source);
            return;
        }

        if (value.Value is InputCoverFile)
        {
            writer.WriteNullValue();
            return;
        }

        throw new JsonException("Unsupported CoverSource value.");
    }
}
