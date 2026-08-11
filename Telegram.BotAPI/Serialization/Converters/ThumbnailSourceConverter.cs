using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Serialization.Converters;

internal sealed class ThumbnailSourceConverter : JsonConverter<ThumbnailSource>
{
    public override ThumbnailSource Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        => reader.GetString() ?? throw new JsonException("Thumbnail source must be a string.");

    public override void Write(Utf8JsonWriter writer, ThumbnailSource value, JsonSerializerOptions options)
    {
        if (value.Value is string source)
        {
            writer.WriteStringValue(source);
            return;
        }

        if (value.Value is InputThumbnailFile)
        {
            writer.WriteNullValue();
            return;
        }

        throw new JsonException("Unsupported ThumbnailSource value.");
    }
}
