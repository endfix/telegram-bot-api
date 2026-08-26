using System;
using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

public abstract class RichText
{
    public abstract RichTextType Type { get; }
}

public sealed class RichTextBold : RichText
{
    public override RichTextType Type => RichTextType.Bold;

    public required RichTextSource Text { get; init; }
}

public sealed class RichTextItalic : RichText
{
    public override RichTextType Type => RichTextType.Italic;

    public required RichTextSource Text { get; init; }
}

public sealed class RichTextUnderline : RichText
{
    public override RichTextType Type => RichTextType.Underline;

    public required RichTextSource Text { get; init; }
}

public sealed class RichTextStrikethrough : RichText
{
    public override RichTextType Type => RichTextType.Strikethrough;

    public required RichTextSource Text { get; init; }
}

public sealed class RichTextSpoiler : RichText
{
    public override RichTextType Type => RichTextType.Spoiler;

    public required RichTextSource Text { get; init; }
}

public sealed class RichTextDateTime : RichText
{
    public override RichTextType Type => RichTextType.DateTime;

    public required RichTextSource Text { get; init; }

    public required long UnixTime { get; init; }

    public required string DateTimeFormat { get; init; }
}

public sealed class RichTextTextMention : RichText
{
    public override RichTextType Type => RichTextType.TextMention;

    public required RichTextSource Text { get; init; }

    public required User User { get; init; }
}

public sealed class RichTextSubscript : RichText
{
    public override RichTextType Type => RichTextType.Subscript;

    public required RichTextSource Text { get; init; }
}

public sealed class RichTextSuperscript : RichText
{
    public override RichTextType Type => RichTextType.Superscript;

    public required RichTextSource Text { get; init; }
}

public sealed class RichTextMarked : RichText
{
    public override RichTextType Type => RichTextType.Marked;

    public required RichTextSource Text { get; init; }
}

public sealed class RichTextCode : RichText
{
    public override RichTextType Type => RichTextType.Code;

    public required RichTextSource Text { get; init; }
}

public sealed class RichTextCustomEmoji : RichText
{
    public override RichTextType Type => RichTextType.CustomEmoji;

    public required string CustomEmojiId { get; init; }

    public required string AlternativeText { get; init; }
}

public sealed class RichTextMathematicalExpression : RichText
{
    public override RichTextType Type => RichTextType.MathematicalExpression;

    public required RichTextSource Expression { get; init; }
}

public sealed class RichTextUrl : RichText
{
    public override RichTextType Type => RichTextType.Url;

    public required RichTextSource Text { get; init; }

    public required RichTextSource Url { get; init; }
}

public sealed class RichTextEmailAddress : RichText
{
    public override RichTextType Type => RichTextType.EmailAddress;

    public required RichTextSource Text { get; init; }

    public required string EmailAddress { get; init; }
}

public sealed class RichTextPhoneNumber : RichText
{
    public override RichTextType Type => RichTextType.PhoneNumber;

    public required RichTextSource Text { get; init; }

    public required string PhoneNumber { get; init; }
}

public sealed class RichTextBankCardNumber : RichText
{
    public override RichTextType Type => RichTextType.BankCardNumber;

    public required RichTextSource Text { get; init; }

    public required string BankCardNumber { get; init; }
}

public sealed class RichTextMention : RichText
{
    public override RichTextType Type => RichTextType.Mention;

    public required RichTextSource Text { get; init; }

    public required string Username { get; init; }
}

public sealed class RichTextHashtag : RichText
{
    public override RichTextType Type => RichTextType.Hashtag;

    public required RichTextSource Text { get; init; }

    public required string Hashtag { get; init; }
}

public sealed class RichTextCashtag : RichText
{
    public override RichTextType Type => RichTextType.Cashtag;

    public required RichTextSource Text { get; init; }

    public required string Cashtag { get; init; }
}

public sealed class RichTextBotCommand : RichText
{
    public override RichTextType Type => RichTextType.BotCommand;

    public required RichTextSource Text { get; init; }

    public required string BotCommand { get; init; }
}

public sealed class RichTextButton : RichText
{
    public override RichTextType Type => RichTextType.Button;

    public required RichMessageButton Button { get; init; }
}

public sealed class RichTextAnchor : RichText
{
    public override RichTextType Type => RichTextType.Anchor;

    public required string Name { get; init; }
}

public sealed class RichTextAnchorLink : RichText
{
    public override RichTextType Type => RichTextType.AnchorLink;

    public required RichTextSource Text { get; init; }

    public required string AnchorName { get; init; }
}

public sealed class RichTextReference : RichText
{
    public override RichTextType Type => RichTextType.Reference;

    public required RichTextSource Text { get; init; }

    public required string Name { get; init; }
}

public sealed class RichTextReferenceLink : RichText
{
    public override RichTextType Type => RichTextType.ReferenceLink;

    public required RichTextSource Text { get; init; }

    public required string ReferenceName { get; init; }
}
