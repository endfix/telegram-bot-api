using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Describes the message that a new message should reply to.</summary>
public sealed class ReplyParameters
{
    /// <summary>Identifier of the message to reply to in the current chat.</summary>
    public long? MessageId { get; init; }

    /// <summary>Chat containing the message to reply to, if it differs from the current chat.</summary>
    public ChatIdSource? ChatId { get; init; }

    /// <summary>Identifier of an incoming ephemeral message to reply to, if applicable.</summary>
    public long? EphemeralMessageId { get; init; }

    /// <summary>Indicates whether to send the message even if the target message is not found.</summary>
    public bool? AllowSendingWithoutReply { get; init; }

    /// <summary>Quoted part of the message to reply to, if supplied.</summary>
    public string? Quote { get; init; }

    /// <summary>Parse mode used for entities in the quote, if supplied.</summary>
    public ParseMode? QuoteParseMode { get; init; }

    /// <summary>Entities that appear in the quote, if supplied instead of a parse mode.</summary>
    public IReadOnlyList<MessageEntity>? QuoteEntities { get; init; }

    /// <summary>
    /// Quoted parts of the rich message to reply to. Must contain one element for each quoted text
    /// of the message, in order of appearance. Each of the following is a separate quoted text:
    /// the text of a paragraph, heading, preformatted block, footer, or mathematical expression;
    /// the text and credit of a block quotation or pull quotation; the summary of a details block;
    /// the caption and each cell of a table; the text and credit of a caption of a media block,
    /// collage, slideshow, or map. Texts of blocks nested in lists, block quotations, details,
    /// collages, and slideshows are separate quoted texts too. The first and last elements can
    /// contain only a part of the corresponding text; all other elements must contain the whole
    /// text. Formatting must be preserved, and rich texts must be nested as in the received
    /// message. Mathematical expressions must be quoted entirely. Buttons in
    /// <c>RichBlockButtons</c>, anchors, and dividers can't be quoted. Up to 32 quoted texts with
    /// a total length of up to 1024 characters can be specified. Only plain text,
    /// <c>RichTextBold</c>, <c>RichTextItalic</c>, <c>RichTextUnderline</c>,
    /// <c>RichTextStrikethrough</c>, <c>RichTextSpoiler</c>, <c>RichTextSubscript</c>,
    /// <c>RichTextSuperscript</c>, <c>RichTextDateTime</c>, <c>RichTextCustomEmoji</c>,
    /// <c>RichTextMathematicalExpression</c>, and arrays of them are kept in the quote; other rich
    /// text types are replaced with their text. If this value is non-empty, <see cref="Quote"/>,
    /// <see cref="QuoteParseMode"/>, and <see cref="QuoteEntities"/> are ignored.
    /// </summary>
    public IReadOnlyList<RichText>? QuoteRichTexts { get; init; }

    /// <summary>
    /// Position of the quote in the original message, in UTF-16 code units. For rich messages, the
    /// position is in the text formed by joining the plain texts of all quotable texts, separated
    /// by line feeds.
    /// </summary>
    public int? QuotePosition { get; init; }

    /// <summary>Identifier of the checklist task to reply to, if applicable.</summary>
    public int? ChecklistTaskId { get; init; }

    /// <summary>Persistent identifier of the poll option to reply to, if applicable.</summary>
    public string? PollOptionId { get; init; }
}
