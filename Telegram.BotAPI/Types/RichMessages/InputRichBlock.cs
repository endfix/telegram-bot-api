using System;
using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Base type for blocks in a rich message to be sent.</summary>
public abstract class InputRichBlock
{
    /// <summary>Gets the input rich block type.</summary>
    public abstract InputRichBlockType Type { get; }
}

/// <summary>A text paragraph.</summary>
public sealed class InputRichBlockParagraph : InputRichBlock
{
    /// <inheritdoc/>
    public override InputRichBlockType Type => InputRichBlockType.Paragraph;

    /// <summary>Text of the paragraph.</summary>
    public required RichText Text { get; init; }
}

/// <summary>A section heading.</summary>
public sealed class InputRichBlockSectionHeading : InputRichBlock
{
    /// <inheritdoc/>
    public override InputRichBlockType Type => InputRichBlockType.Heading;

    /// <summary>Text of the heading.</summary>
    public required RichText Text { get; init; }

    /// <summary>Relative font size of the heading; 1 is the largest and 6 is the smallest.</summary>
    public required int Size { get; init; }
}

/// <summary>A preformatted text block.</summary>
public sealed class InputRichBlockPreformatted : InputRichBlock
{
    /// <inheritdoc/>
    public override InputRichBlockType Type => InputRichBlockType.Pre;

    /// <summary>Text of the preformatted block.</summary>
    public required RichText Text { get; init; }

    /// <summary>Optional. Programming language of the text.</summary>
    public string? Language { get; init; }
}

/// <summary>A footer.</summary>
public sealed class InputRichBlockFooter : InputRichBlock
{
    /// <inheritdoc/>
    public override InputRichBlockType Type => InputRichBlockType.Footer;

    /// <summary>Text of the footer.</summary>
    public required RichText Text { get; init; }
}

/// <summary>A horizontal divider.</summary>
public sealed class InputRichBlockDivider : InputRichBlock
{
    /// <inheritdoc/>
    public override InputRichBlockType Type => InputRichBlockType.Divider;
}

/// <summary>A block containing a mathematical expression in LaTeX format.</summary>
public sealed class InputRichBlockMathematicalExpression : InputRichBlock
{
    /// <inheritdoc/>
    public override InputRichBlockType Type => InputRichBlockType.MathematicalExpression;

    /// <summary>Mathematical expression in LaTeX format.</summary>
    public required string Expression { get; init; }
}

/// <summary>A named anchor.</summary>
public sealed class InputRichBlockAnchor : InputRichBlock
{
    /// <inheritdoc/>
    public override InputRichBlockType Type => InputRichBlockType.Anchor;

    /// <summary>Name of the anchor.</summary>
    public required string Name { get; init; }
}

/// <summary>A list of rich block items.</summary>
public sealed class InputRichBlockList : InputRichBlock
{
    /// <inheritdoc/>
    public override InputRichBlockType Type => InputRichBlockType.List;

    /// <summary>Items of the list.</summary>
    public required IReadOnlyList<InputRichBlockListItem> Items { get; init; }
}

/// <summary>A block quotation.</summary>
public sealed class InputRichBlockBlockQuotation : InputRichBlock
{
    /// <inheritdoc/>
    public override InputRichBlockType Type => InputRichBlockType.Blockquote;

    /// <summary>Content of the quotation.</summary>
    public required IReadOnlyList<InputRichBlock> Blocks { get; init; }

    /// <summary>Optional. Credit displayed with the quotation.</summary>
    public RichText? Credit { get; init; }
}

/// <summary>An expandable block quotation.</summary>
public sealed class InputRichBlockExpandableBlockQuotation : InputRichBlock
{
    /// <inheritdoc/>
    public override InputRichBlockType Type => InputRichBlockType.ExpandableBlockquote;

    /// <summary>Content of the quotation.</summary>
    public required RichText Text { get; init; }

    /// <summary>Optional. Credit displayed with the quotation.</summary>
    public RichText? Credit { get; init; }
}

/// <summary>A centered pull quotation.</summary>
public sealed class InputRichBlockPullQuotation : InputRichBlock
{
    /// <inheritdoc/>
    public override InputRichBlockType Type => InputRichBlockType.Pullquote;

    /// <summary>Text of the quotation.</summary>
    public required RichText Text { get; init; }

    /// <summary>Optional. Credit displayed with the quotation.</summary>
    public RichText? Credit { get; init; }
}

/// <summary>A collage of rich blocks.</summary>
public sealed class InputRichBlockCollage : InputRichBlock
{
    /// <inheritdoc/>
    public override InputRichBlockType Type => InputRichBlockType.Collage;

    /// <summary>Elements of the collage.</summary>
    public required IReadOnlyList<InputRichBlock> Blocks { get; init; }

    /// <summary>Optional. Caption of the collage.</summary>
    public RichBlockCaption? Caption { get; init; }
}

/// <summary>A slideshow of rich blocks.</summary>
public sealed class InputRichBlockSlideshow : InputRichBlock
{
    /// <inheritdoc/>
    public override InputRichBlockType Type => InputRichBlockType.Slideshow;

    /// <summary>Elements of the slideshow.</summary>
    public required IReadOnlyList<InputRichBlock> Blocks { get; init; }

    /// <summary>Optional. Caption of the slideshow.</summary>
    public RichBlockCaption? Caption { get; init; }
}

/// <summary>A table in a rich message.</summary>
public sealed class InputRichBlockTable : InputRichBlock
{
    /// <inheritdoc/>
    public override InputRichBlockType Type => InputRichBlockType.Table;

    /// <summary>Rows and cells of the table.</summary>
    public required IReadOnlyList<IReadOnlyList<RichBlockTableCell>> Cells { get; init; }

    /// <summary>Optional. Indicates whether the table has borders.</summary>
    public bool? IsBordered { get; init; }

    /// <summary>Optional. Indicates whether the table has striped rows.</summary>
    public bool? IsStriped { get; init; }

    /// <summary>Optional. Indicates whether table cells use smaller indents.</summary>
    public bool? IsCompact { get; init; }

    /// <summary>Optional. Caption of the table.</summary>
    public RichText? Caption { get; init; }
}

/// <summary>An expandable details block.</summary>
public sealed class InputRichBlockDetails : InputRichBlock
{
    /// <inheritdoc/>
    public override InputRichBlockType Type => InputRichBlockType.Details;

    /// <summary>Always-visible summary of the block.</summary>
    public required RichText Summary { get; init; }

    /// <summary>Content revealed by the details block.</summary>
    public required IReadOnlyList<InputRichBlock> Blocks { get; init; }

    /// <summary>Optional. Indicates whether the content is visible by default.</summary>
    public bool? IsOpen { get; init; }
}

/// <summary>A map block.</summary>
public sealed class InputRichBlockMap : InputRichBlock
{
    /// <inheritdoc/>
    public override InputRichBlockType Type => InputRichBlockType.Map;

    /// <summary>Center location of the map.</summary>
    public required Location Location { get; init; }

    /// <summary>Optional. Map zoom level; 0-24.</summary>
    public int? Zoom { get; init; }

    /// <summary>Optional. Expected map width; 0-10000.</summary>
    public int? Width { get; init; }

    /// <summary>Optional. Expected map height; 0-10000.</summary>
    public int? Height { get; init; }

    /// <summary>Optional. Caption of the map.</summary>
    public RichBlockCaption? Caption { get; init; }
}

/// <summary>A row of buttons in a rich message.</summary>
public sealed class InputRichBlockButtons : InputRichBlock
{
    /// <inheritdoc/>
    public override InputRichBlockType Type => InputRichBlockType.Buttons;

    /// <summary>List of buttons in the row; 1-8 buttons are allowed.</summary>
    public required IReadOnlyList<RichMessageButton> Buttons { get; init; }

    /// <summary>Optional. Horizontal alignment of the buttons.</summary>
    public InputRichBlockButtonsAlign? Align { get; init; }
}

/// <summary>An animation media block.</summary>
public sealed class InputRichBlockAnimation : InputRichBlock
{
    /// <inheritdoc/>
    public override InputRichBlockType Type => InputRichBlockType.Animation;

    /// <summary>Animation to send.</summary>
    public required InputMediaAnimation Animation { get; init; }

    /// <summary>Optional. Caption of the animation.</summary>
    public RichBlockCaption? Caption { get; init; }
}

/// <summary>An audio media block.</summary>
public sealed class InputRichBlockAudio : InputRichBlock
{
    /// <inheritdoc/>
    public override InputRichBlockType Type => InputRichBlockType.Audio;

    /// <summary>Audio to send.</summary>
    public required InputMediaAudio Audio { get; init; }

    /// <summary>Optional. Caption of the audio.</summary>
    public RichBlockCaption? Caption { get; init; }
}

/// <summary>A document media block.</summary>
public sealed class InputRichBlockDocument : InputRichBlock
{
    /// <inheritdoc/>
    public override InputRichBlockType Type => InputRichBlockType.Document;

    /// <summary>Document to send.</summary>
    public required InputMediaDocument Document { get; init; }

    /// <summary>Optional. Caption of the document.</summary>
    public RichBlockCaption? Caption { get; init; }
}

/// <summary>A photo media block.</summary>
public sealed class InputRichBlockPhoto : InputRichBlock
{
    /// <inheritdoc/>
    public override InputRichBlockType Type => InputRichBlockType.Photo;

    /// <summary>Photo to send.</summary>
    public required InputMediaPhoto Photo { get; init; }

    /// <summary>Optional. Caption of the photo.</summary>
    public RichBlockCaption? Caption { get; init; }
}

/// <summary>A video media block.</summary>
public sealed class InputRichBlockVideo : InputRichBlock
{
    /// <inheritdoc/>
    public override InputRichBlockType Type => InputRichBlockType.Video;

    /// <summary>Video to send.</summary>
    public required InputMediaVideo Video { get; init; }

    /// <summary>Optional. Caption of the video.</summary>
    public RichBlockCaption? Caption { get; init; }
}

/// <summary>A voice note media block.</summary>
public sealed class InputRichBlockVoiceNote : InputRichBlock
{
    /// <inheritdoc/>
    public override InputRichBlockType Type => InputRichBlockType.VoiceNote;

    /// <summary>Voice note to send.</summary>
    public required InputMediaVoiceNote VoiceNote { get; init; }

    /// <summary>Optional. Caption of the voice note.</summary>
    public RichBlockCaption? Caption { get; init; }
}

/// <summary>A “Thinking...” placeholder block for streamed rich message drafts.</summary>
public sealed class InputRichBlockThinking : InputRichBlock
{
    /// <inheritdoc/>
    public override InputRichBlockType Type => InputRichBlockType.Thinking;

    /// <summary>Text displayed in the placeholder.</summary>
    public required RichText Text { get; init; }
}
