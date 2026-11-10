using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Contains information about the quoted part of a message being replied to.</summary>
public sealed class TextQuote
{
    /// <summary>Text of the quoted part; may be empty when the quote was chosen from a rich message.</summary>
    public required string Text { get; init; }

    /// <summary>Special entities that appear in the quote, if available.</summary>
    public IReadOnlyList<MessageEntity>? Entities { get; init; }

    /// <summary>
    /// Rich text of the quote when it was chosen from a rich message. May contain only plain text,
    /// <c>RichTextBold</c>, <c>RichTextItalic</c>, <c>RichTextUnderline</c>,
    /// <c>RichTextStrikethrough</c>, <c>RichTextSpoiler</c>, <c>RichTextSubscript</c>,
    /// <c>RichTextSuperscript</c>, <c>RichTextDateTime</c>, <c>RichTextCustomEmoji</c>,
    /// <c>RichTextMathematicalExpression</c>, and arrays of them.
    /// </summary>
    public IReadOnlyList<RichText>? RichTexts { get; init; }

    /// <summary>
    /// Approximate position of the quote in the original message, in UTF-16 code units. For rich
    /// messages, the position is in the text formed by joining the plain texts of all quotable
    /// texts, separated by line feeds.
    /// </summary>
    public required int Position { get; init; }

    /// <summary>Indicates whether the quote was chosen manually by the message sender.</summary>
    public bool? IsManual { get; init; }
}
