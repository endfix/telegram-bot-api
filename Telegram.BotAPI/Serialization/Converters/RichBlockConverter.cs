using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Endfix.Telegram.BotAPI.Enums;
using Endfix.Telegram.BotAPI.Extensions;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Serialization.Converters;

internal sealed class RichBlockConverter : JsonConverter<RichBlock>
{
    public override RichBlock? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var jsonDocument = JsonDocument.ParseValue(ref reader);
        var root = jsonDocument.RootElement;

        if (!root.TryGetProperty("type", out var typeProperty) || !typeProperty.TryGetEnum<RichBlockType>(options, out var richBlockType))
        {
            throw new JsonException("Missing discriminator 'type' in RichBlock");
        }

        return richBlockType switch
        {
            RichBlockType.Paragraph => root.Deserialize<RichBlockParagraph>(options),
            RichBlockType.Heading => root.Deserialize<RichBlockSectionHeading>(options),
            RichBlockType.Pre => root.Deserialize<RichBlockPreformatted>(options),
            RichBlockType.Footer => root.Deserialize<RichBlockFooter>(options),
            RichBlockType.Divider => root.Deserialize<RichBlockDivider>(options),
            RichBlockType.MathematicalExpression => root.Deserialize<RichBlockMathematicalExpression>(options),
            RichBlockType.Anchor => root.Deserialize<RichBlockAnchor>(options),
            RichBlockType.List => root.Deserialize<RichBlockList>(options),
            RichBlockType.Blockquote => root.Deserialize<RichBlockBlockQuotation>(options),
            RichBlockType.ExpandableBlockquote => root.Deserialize<RichBlockExpandableBlockQuotation>(options),
            RichBlockType.Pullquote => root.Deserialize<RichBlockPullQuotation>(options),
            RichBlockType.Collage => root.Deserialize<RichBlockCollage>(options),
            RichBlockType.Slideshow => root.Deserialize<RichBlockSlideshow>(options),
            RichBlockType.Table => root.Deserialize<RichBlockTable>(options),
            RichBlockType.Details => root.Deserialize<RichBlockDetails>(options),
            RichBlockType.Map => root.Deserialize<RichBlockMap>(options),
            RichBlockType.Buttons => root.Deserialize<RichBlockButtons>(options),
            RichBlockType.Animation => root.Deserialize<RichBlockAnimation>(options),
            RichBlockType.Audio => root.Deserialize<RichBlockAudio>(options),
            RichBlockType.Document => root.Deserialize<RichBlockDocument>(options),
            RichBlockType.Photo => root.Deserialize<RichBlockPhoto>(options),
            RichBlockType.Video => root.Deserialize<RichBlockVideo>(options),
            RichBlockType.VoiceNote => root.Deserialize<RichBlockVoiceNote>(options),
            RichBlockType.Thinking => root.Deserialize<RichBlockThinking>(options),
            _ => throw new JsonException($"Unknown RichBlock type: {typeProperty.GetString()}")
        };
    }

    public override void Write(Utf8JsonWriter writer, RichBlock value, JsonSerializerOptions options)
    {
        if (value is null)
        {
            writer.WriteNullValue();
            return;
        }

        JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
}
