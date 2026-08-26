using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Serialization.Converters;

internal sealed class StickerSourceConverter : JsonConverter<StickerSource>
{
    public override StickerSource Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        => reader.GetString() ?? throw new JsonException("Sticker source must be a string.");

    public override void Write(Utf8JsonWriter writer, StickerSource value, JsonSerializerOptions options)
    {
        if (value.Value is string source)
        {
            writer.WriteStringValue(source);
            return;
        }

        if (value.Value is InputStickerFile)
        {
            writer.WriteNullValue();
            return;
        }

        throw new JsonException("Unsupported StickerSource value.");
    }
}
