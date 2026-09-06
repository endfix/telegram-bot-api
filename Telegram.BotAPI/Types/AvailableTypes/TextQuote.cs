using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Contains information about the quoted part of a message being replied to.</summary>
public sealed class TextQuote
{
    /// <summary>Text of the quoted part.</summary>
    public required string Text { get; init; }

    /// <summary>Special entities that appear in the quote, if available.</summary>
    public IReadOnlyList<MessageEntity>? Entities { get; init; }

    /// <summary>Approximate position of the quote in the original message, in UTF-16 code units.</summary>
    public required int Position { get; init; }

    /// <summary>Indicates whether the quote was chosen manually by the message sender.</summary>
    public bool? IsManual { get; init; }
}
