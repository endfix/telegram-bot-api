namespace Endfix.Telegram.BotAPI.Enums;

/// <summary>Identifies a block variant supplied as rich message content.</summary>
public enum InputRichBlockType
{
    /// <summary>A paragraph.</summary>
    Paragraph,
    /// <summary>A section heading.</summary>
    Heading,
    /// <summary>A preformatted text block.</summary>
    Pre,
    /// <summary>A footer.</summary>
    Footer,
    /// <summary>A divider.</summary>
    Divider,
    /// <summary>A mathematical expression.</summary>
    MathematicalExpression,
    /// <summary>A named anchor.</summary>
    Anchor,
    /// <summary>A list.</summary>
    List,
    /// <summary>A block quotation.</summary>
    Blockquote,
    /// <summary>An expandable block quotation.</summary>
    ExpandableBlockquote,
    /// <summary>A pull quotation.</summary>
    Pullquote,
    /// <summary>A media collage.</summary>
    Collage,
    /// <summary>A media slideshow.</summary>
    Slideshow,
    /// <summary>A table.</summary>
    Table,
    /// <summary>An expandable details block.</summary>
    Details,
    /// <summary>A map.</summary>
    Map,
    /// <summary>A row of buttons.</summary>
    Buttons,
    /// <summary>An animation.</summary>
    Animation,
    /// <summary>An audio file.</summary>
    Audio,
    /// <summary>A general document.</summary>
    Document,
    /// <summary>A photo.</summary>
    Photo,
    /// <summary>A video.</summary>
    Video,
    /// <summary>A voice note.</summary>
    VoiceNote,
    /// <summary>A message-generation placeholder usable only while streaming a draft.</summary>
    Thinking
}
