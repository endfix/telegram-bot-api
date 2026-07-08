using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telegram.BotAPI.Enums;
using Telegram.BotAPI.Extensions;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Serialization.Converters;

public sealed class RichTextConverter : JsonConverter<RichText>
{
    public override RichText? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var jsonDocument = JsonDocument.ParseValue(ref reader);
        var root = jsonDocument.RootElement;

        if (!root.TryGetProperty("type", out var typeProperty) || !typeProperty.TryGetEnum<RichTextType>(options, out var richTextType))
        {
            throw new JsonException("Missing discriminator 'type' in RichText");
        }

        return richTextType switch
        {
            RichTextType.Bold => root.Deserialize<RichTextBold>(options),
            RichTextType.Italic => root.Deserialize<RichTextItalic>(options),
            RichTextType.Underline => root.Deserialize<RichTextUnderline>(options),
            RichTextType.Strikethrough => root.Deserialize<RichTextStrikethrough>(options),
            RichTextType.Spoiler => root.Deserialize<RichTextSpoiler>(options),
            RichTextType.DateTime => root.Deserialize<RichTextDateTime>(options),
            RichTextType.TextMention => root.Deserialize<RichTextTextMention>(options),
            RichTextType.Subscript => root.Deserialize<RichTextSubscript>(options),
            RichTextType.Superscript => root.Deserialize<RichTextSuperscript>(options),
            RichTextType.Marked => root.Deserialize<RichTextMarked>(options),
            RichTextType.Code => root.Deserialize<RichTextCode>(options),
            RichTextType.CustomEmoji => root.Deserialize<RichTextCustomEmoji>(options),
            RichTextType.MathematicalExpression => root.Deserialize<RichTextMathematicalExpression>(options),
            RichTextType.Url => root.Deserialize<RichTextUrl>(options),
            RichTextType.EmailAddress => root.Deserialize<RichTextEmailAddress>(options),
            RichTextType.PhoneNumber => root.Deserialize<RichTextPhoneNumber>(options),
            RichTextType.BankCardNumber => root.Deserialize<RichTextBankCardNumber>(options),
            RichTextType.Mention => root.Deserialize<RichTextMention>(options),
            RichTextType.Hashtag => root.Deserialize<RichTextHashtag>(options),
            RichTextType.Cashtag => root.Deserialize<RichTextCashtag>(options),
            RichTextType.BotCommand => root.Deserialize<RichTextBotCommand>(options),
            RichTextType.Anchor => root.Deserialize<RichTextAnchor>(options),
            RichTextType.AnchorLink => root.Deserialize<RichTextAnchorLink>(options),
            RichTextType.Reference => root.Deserialize<RichTextReference>(options),
            RichTextType.ReferenceLink => root.Deserialize<RichTextReferenceLink>(options),
            _ => throw new JsonException($"Unknown RichText type: {typeProperty.GetString()}")
        };
    }

    public override void Write(Utf8JsonWriter writer, RichText value, JsonSerializerOptions options)
    {
        if (value is null)
        {
            writer.WriteNullValue();
            return;
        }

        JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
}
