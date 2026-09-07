using System;
using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Base type for rich formatted text entities.</summary>
public abstract class RichText
{
    /// <summary>Gets the rich text entity type.</summary>
    public abstract RichTextType Type { get; }
}

/// <summary>Bold text.</summary>
public sealed class RichTextBold : RichText
{
    /// <inheritdoc/>
    public override RichTextType Type => RichTextType.Bold;

    /// <summary>Text to display in bold.</summary>
    public required RichTextSource Text { get; init; }
}

/// <summary>Italic text.</summary>
public sealed class RichTextItalic : RichText
{
    /// <inheritdoc/>
    public override RichTextType Type => RichTextType.Italic;

    /// <summary>Text to display in italics.</summary>
    public required RichTextSource Text { get; init; }
}

/// <summary>Underlined text.</summary>
public sealed class RichTextUnderline : RichText
{
    /// <inheritdoc/>
    public override RichTextType Type => RichTextType.Underline;

    /// <summary>Text to underline.</summary>
    public required RichTextSource Text { get; init; }
}

/// <summary>Strikethrough text.</summary>
public sealed class RichTextStrikethrough : RichText
{
    /// <inheritdoc/>
    public override RichTextType Type => RichTextType.Strikethrough;

    /// <summary>Text to display with a strikethrough.</summary>
    public required RichTextSource Text { get; init; }
}

/// <summary>Spoiler text.</summary>
public sealed class RichTextSpoiler : RichText
{
    /// <inheritdoc/>
    public override RichTextType Type => RichTextType.Spoiler;

    /// <summary>Text hidden as a spoiler.</summary>
    public required RichTextSource Text { get; init; }
}

/// <summary>Text displayed as a date and time.</summary>
public sealed class RichTextDateTime : RichText
{
    /// <inheritdoc/>
    public override RichTextType Type => RichTextType.DateTime;

    /// <summary>Text associated with the date and time.</summary>
    public required RichTextSource Text { get; init; }

    /// <summary>Date and time in Unix time.</summary>
    public required long UnixTime { get; init; }

    /// <summary>Format used to display the date and time.</summary>
    public required string DateTimeFormat { get; init; }
}

/// <summary>Text that mentions a Telegram user.</summary>
public sealed class RichTextTextMention : RichText
{
    /// <inheritdoc/>
    public override RichTextType Type => RichTextType.TextMention;

    /// <summary>Text displayed for the mention.</summary>
    public required RichTextSource Text { get; init; }

    /// <summary>User mentioned by the text.</summary>
    public required User User { get; init; }
}

/// <summary>Subscript text.</summary>
public sealed class RichTextSubscript : RichText
{
    /// <inheritdoc/>
    public override RichTextType Type => RichTextType.Subscript;

    /// <summary>Text displayed as a subscript.</summary>
    public required RichTextSource Text { get; init; }
}

/// <summary>Superscript text.</summary>
public sealed class RichTextSuperscript : RichText
{
    /// <inheritdoc/>
    public override RichTextType Type => RichTextType.Superscript;

    /// <summary>Text displayed as a superscript.</summary>
    public required RichTextSource Text { get; init; }
}

/// <summary>Marked text.</summary>
public sealed class RichTextMarked : RichText
{
    /// <inheritdoc/>
    public override RichTextType Type => RichTextType.Marked;

    /// <summary>Text to mark.</summary>
    public required RichTextSource Text { get; init; }
}

/// <summary>Inline code text.</summary>
public sealed class RichTextCode : RichText
{
    /// <inheritdoc/>
    public override RichTextType Type => RichTextType.Code;

    /// <summary>Code text.</summary>
    public required RichTextSource Text { get; init; }
}

/// <summary>Text represented by a custom emoji.</summary>
public sealed class RichTextCustomEmoji : RichText
{
    /// <inheritdoc/>
    public override RichTextType Type => RichTextType.CustomEmoji;

    /// <summary>Identifier of the custom emoji.</summary>
    public required string CustomEmojiId { get; init; }

    /// <summary>Alternative text for the custom emoji.</summary>
    public required string AlternativeText { get; init; }
}

/// <summary>A mathematical expression in LaTeX format.</summary>
public sealed class RichTextMathematicalExpression : RichText
{
    /// <inheritdoc/>
    public override RichTextType Type => RichTextType.MathematicalExpression;

    /// <summary>Mathematical expression in LaTeX format.</summary>
    public required RichTextSource Expression { get; init; }
}

/// <summary>Text linked to a URL.</summary>
public sealed class RichTextUrl : RichText
{
    /// <inheritdoc/>
    public override RichTextType Type => RichTextType.Url;

    /// <summary>Text displayed as the link.</summary>
    public required RichTextSource Text { get; init; }

    /// <summary>URL opened by the link.</summary>
    public required string Url { get; init; }
}

/// <summary>Text linked to an email address.</summary>
public sealed class RichTextEmailAddress : RichText
{
    /// <inheritdoc/>
    public override RichTextType Type => RichTextType.EmailAddress;

    /// <summary>Text displayed as the email link.</summary>
    public required RichTextSource Text { get; init; }

    /// <summary>Email address opened by the link.</summary>
    public required string EmailAddress { get; init; }
}

/// <summary>Text linked to a phone number.</summary>
public sealed class RichTextPhoneNumber : RichText
{
    /// <inheritdoc/>
    public override RichTextType Type => RichTextType.PhoneNumber;

    /// <summary>Text displayed as the phone link.</summary>
    public required RichTextSource Text { get; init; }

    /// <summary>Phone number opened by the link.</summary>
    public required string PhoneNumber { get; init; }
}

/// <summary>Text representing a bank card number.</summary>
public sealed class RichTextBankCardNumber : RichText
{
    /// <inheritdoc/>
    public override RichTextType Type => RichTextType.BankCardNumber;

    /// <summary>Text displayed for the bank card number.</summary>
    public required RichTextSource Text { get; init; }

    /// <summary>Bank card number.</summary>
    public required string BankCardNumber { get; init; }
}

/// <summary>Text mentioning a Telegram username.</summary>
public sealed class RichTextMention : RichText
{
    /// <inheritdoc/>
    public override RichTextType Type => RichTextType.Mention;

    /// <summary>Text displayed for the mention.</summary>
    public required RichTextSource Text { get; init; }

    /// <summary>Telegram username being mentioned.</summary>
    public required string Username { get; init; }
}

/// <summary>Hashtag text.</summary>
public sealed class RichTextHashtag : RichText
{
    /// <inheritdoc/>
    public override RichTextType Type => RichTextType.Hashtag;

    /// <summary>Text displayed for the hashtag.</summary>
    public required RichTextSource Text { get; init; }

    /// <summary>Hashtag value.</summary>
    public required string Hashtag { get; init; }
}

/// <summary>Cashtag text.</summary>
public sealed class RichTextCashtag : RichText
{
    /// <inheritdoc/>
    public override RichTextType Type => RichTextType.Cashtag;

    /// <summary>Text displayed for the cashtag.</summary>
    public required RichTextSource Text { get; init; }

    /// <summary>Cashtag value.</summary>
    public required string Cashtag { get; init; }
}

/// <summary>Bot command text.</summary>
public sealed class RichTextBotCommand : RichText
{
    /// <inheritdoc/>
    public override RichTextType Type => RichTextType.BotCommand;

    /// <summary>Text displayed for the command.</summary>
    public required RichTextSource Text { get; init; }

    /// <summary>Bot command.</summary>
    public required string BotCommand { get; init; }
}

/// <summary>Text containing a rich message button.</summary>
public sealed class RichTextButton : RichText
{
    /// <inheritdoc/>
    public override RichTextType Type => RichTextType.Button;

    /// <summary>Button embedded in the text.</summary>
    public required RichMessageButton Button { get; init; }
}

/// <summary>An anchor in a rich message.</summary>
public sealed class RichTextAnchor : RichText
{
    /// <inheritdoc/>
    public override RichTextType Type => RichTextType.Anchor;

    /// <summary>Name of the anchor.</summary>
    public required string Name { get; init; }
}

/// <summary>Text linked to an anchor.</summary>
public sealed class RichTextAnchorLink : RichText
{
    /// <inheritdoc/>
    public override RichTextType Type => RichTextType.AnchorLink;

    /// <summary>Text displayed as the anchor link.</summary>
    public required RichTextSource Text { get; init; }

    /// <summary>Name of the target anchor.</summary>
    public required string AnchorName { get; init; }
}

/// <summary>Text linked to a reference.</summary>
public sealed class RichTextReference : RichText
{
    /// <inheritdoc/>
    public override RichTextType Type => RichTextType.Reference;

    /// <summary>Text displayed for the reference.</summary>
    public required RichTextSource Text { get; init; }

    /// <summary>Name of the reference.</summary>
    public required string Name { get; init; }
}

/// <summary>Text linked to a named reference.</summary>
public sealed class RichTextReferenceLink : RichText
{
    /// <inheritdoc/>
    public override RichTextType Type => RichTextType.ReferenceLink;

    /// <summary>Text displayed as the reference link.</summary>
    public required RichTextSource Text { get; init; }

    /// <summary>Name of the target reference.</summary>
    public required string ReferenceName { get; init; }
}
