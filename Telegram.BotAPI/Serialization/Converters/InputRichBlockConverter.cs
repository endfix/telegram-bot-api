using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Enums;
using Telegram.BotAPI.Extensions;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Serialization.Converters;

internal sealed class InputRichBlockConverter : JsonConverter<InputRichBlock>
{
    public override InputRichBlock? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;

        if (!root.TryGetProperty("type", out var typeProperty) || !typeProperty.TryGetEnum<InputRichBlockType>(options, out var type))
        {
            throw new JsonException("Missing discriminator 'type' in InputRichBlock");
        }

        return type switch
        {
            InputRichBlockType.Paragraph => root.Deserialize<InputRichBlockParagraph>(options),
            InputRichBlockType.Heading => root.Deserialize<InputRichBlockSectionHeading>(options),
            InputRichBlockType.Pre => root.Deserialize<InputRichBlockPreformatted>(options),
            InputRichBlockType.Footer => root.Deserialize<InputRichBlockFooter>(options),
            InputRichBlockType.Divider => root.Deserialize<InputRichBlockDivider>(options),
            InputRichBlockType.MathematicalExpression => root.Deserialize<InputRichBlockMathematicalExpression>(options),
            InputRichBlockType.Anchor => root.Deserialize<InputRichBlockAnchor>(options),
            InputRichBlockType.List => root.Deserialize<InputRichBlockList>(options),
            InputRichBlockType.Blockquote => root.Deserialize<InputRichBlockBlockQuotation>(options),
            InputRichBlockType.ExpandableBlockquote => root.Deserialize<InputRichBlockExpandableBlockQuotation>(options),
            InputRichBlockType.Pullquote => root.Deserialize<InputRichBlockPullQuotation>(options),
            InputRichBlockType.Collage => root.Deserialize<InputRichBlockCollage>(options),
            InputRichBlockType.Slideshow => root.Deserialize<InputRichBlockSlideshow>(options),
            InputRichBlockType.Table => root.Deserialize<InputRichBlockTable>(options),
            InputRichBlockType.Details => root.Deserialize<InputRichBlockDetails>(options),
            InputRichBlockType.Map => root.Deserialize<InputRichBlockMap>(options),
            InputRichBlockType.Buttons => root.Deserialize<InputRichBlockButtons>(options),
            InputRichBlockType.Animation => root.Deserialize<InputRichBlockAnimation>(options),
            InputRichBlockType.Audio => root.Deserialize<InputRichBlockAudio>(options),
            InputRichBlockType.Document => root.Deserialize<InputRichBlockDocument>(options),
            InputRichBlockType.Photo => root.Deserialize<InputRichBlockPhoto>(options),
            InputRichBlockType.Video => root.Deserialize<InputRichBlockVideo>(options),
            InputRichBlockType.VoiceNote => root.Deserialize<InputRichBlockVoiceNote>(options),
            InputRichBlockType.Thinking => root.Deserialize<InputRichBlockThinking>(options),
            _ => throw new JsonException($"Unknown InputRichBlock type: {type}")
        };
    }

    public override void Write(Utf8JsonWriter writer, InputRichBlock value, JsonSerializerOptions options)
    {
        if (value is null)
        {
            writer.WriteNullValue();
            return;
        }

        JsonSerializer.Serialize(writer, (object)value, options);
    }
}
