namespace Endfix.Telegram.BotAPI.Enums;

/// <summary>Identifies the semantic or formatting role of an entity in message text.</summary>
public enum MessageEntityType
{
    /// <summary>A mention in the form <c>@username</c>.</summary>
    Mention,

    /// <summary>A hashtag.</summary>
    Hashtag,

    /// <summary>A cashtag.</summary>
    Cashtag,

    /// <summary>A bot command.</summary>
    BotCommand,

    /// <summary>An automatically recognized URL.</summary>
    Url,

    /// <summary>An email address.</summary>
    Email,

    /// <summary>A phone number.</summary>
    PhoneNumber,

    /// <summary>Bold text.</summary>
    Bold,

    /// <summary>Italic text.</summary>
    Italic,

    /// <summary>Underlined text.</summary>
    Underline,

    /// <summary>Strikethrough text.</summary>
    Strikethrough,

    /// <summary>Spoiler text.</summary>
    Spoiler,

    /// <summary>A block quotation.</summary>
    Blockquote,

    /// <summary>A collapsed-by-default block quotation.</summary>
    ExpandableBlockquote,

    /// <summary>Inline monospaced code.</summary>
    Code,

    /// <summary>A monospaced code block.</summary>
    Pre,

    /// <summary>Text containing an explicit clickable URL.</summary>
    TextLink,

    /// <summary>A mention of a user without relying on a username.</summary>
    TextMention,

    /// <summary>An inline custom emoji.</summary>
    CustomEmoji,

    /// <summary>A formatted date and time.</summary>
    DateTime
}
