namespace Endfix.Telegram.BotAPI.Enums;

/// <summary>Identifies a rich-text node variant.</summary>
public enum RichTextType
{
    /// <summary>Bold text.</summary>
    Bold,
    /// <summary>Italic text.</summary>
    Italic,
    /// <summary>Underlined text.</summary>
    Underline,
    /// <summary>Strikethrough text.</summary>
    Strikethrough,
    /// <summary>Text hidden behind a spoiler.</summary>
    Spoiler,
    /// <summary>A formatted date and time.</summary>
    DateTime,
    /// <summary>A mention of a specific user.</summary>
    TextMention,
    /// <summary>Subscript text.</summary>
    Subscript,
    /// <summary>Superscript text.</summary>
    Superscript,
    /// <summary>Highlighted or marked text.</summary>
    Marked,
    /// <summary>Inline monospaced code.</summary>
    Code,
    /// <summary>An inline custom emoji.</summary>
    CustomEmoji,
    /// <summary>A mathematical expression.</summary>
    MathematicalExpression,
    /// <summary>A URL.</summary>
    Url,
    /// <summary>An email address.</summary>
    EmailAddress,
    /// <summary>A phone number.</summary>
    PhoneNumber,
    /// <summary>A bank card number.</summary>
    BankCardNumber,
    /// <summary>A username mention.</summary>
    Mention,
    /// <summary>A hashtag.</summary>
    Hashtag,
    /// <summary>A cashtag.</summary>
    Cashtag,
    /// <summary>A bot command.</summary>
    BotCommand,
    /// <summary>An interactive button.</summary>
    Button,
    /// <summary>A named anchor.</summary>
    Anchor,
    /// <summary>A link to a named anchor.</summary>
    AnchorLink,
    /// <summary>A named reference.</summary>
    Reference,
    /// <summary>A link to a named reference.</summary>
    ReferenceLink
}
