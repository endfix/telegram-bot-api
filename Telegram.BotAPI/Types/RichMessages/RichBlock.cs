using System;
using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Base type for blocks in a rich formatted message received from Telegram.</summary>
public abstract class RichBlock
{
    /// <summary>Gets the rich block type.</summary>
    public abstract RichBlockType Type { get; }
}

/// <summary>A paragraph of rich text.</summary>
public sealed class RichBlockParagraph : RichBlock
{
    /// <inheritdoc/>
    public override RichBlockType Type => RichBlockType.Paragraph;

    /// <summary>Text of the paragraph.</summary>
    public required RichTextSource Text { get; init; }
}

/// <summary>A section heading.</summary>
public sealed class RichBlockSectionHeading : RichBlock
{
    /// <inheritdoc/>
    public override RichBlockType Type => RichBlockType.Heading;

    /// <summary>Text of the heading.</summary>
    public required RichTextSource Text { get; init; }

    /// <summary>Relative font size of the heading.</summary>
    public required int Size { get; init; }
}

/// <summary>A preformatted text block.</summary>
public sealed class RichBlockPreformatted : RichBlock
{
    /// <inheritdoc/>
    public override RichBlockType Type => RichBlockType.Pre;

    /// <summary>Text of the preformatted block.</summary>
    public required RichTextSource Text { get; init; }

    /// <summary>Optional. Programming language of the text.</summary>
    public string? Language { get; init; }
}

/// <summary>A footer.</summary>
public sealed class RichBlockFooter : RichBlock
{
    /// <inheritdoc/>
    public override RichBlockType Type => RichBlockType.Footer;

    /// <summary>Text of the footer.</summary>
    public required RichTextSource Text { get; init; }
}

/// <summary>A horizontal divider.</summary>
public sealed class RichBlockDivider : RichBlock
{
    /// <inheritdoc/>
    public override RichBlockType Type => RichBlockType.Divider;
}

/// <summary>A block containing a mathematical expression.</summary>
public sealed class RichBlockMathematicalExpression : RichBlock
{
    /// <inheritdoc/>
    public override RichBlockType Type => RichBlockType.MathematicalExpression;

    /// <summary>Mathematical expression in LaTeX format.</summary>
    public required string Expression { get; init; }
}

/// <summary>A named anchor.</summary>
public sealed class RichBlockAnchor : RichBlock
{
    /// <inheritdoc/>
    public override RichBlockType Type => RichBlockType.Anchor;

    /// <summary>Name of the anchor.</summary>
    public required string Name { get; init; }
}

/// <summary>A list of rich block items.</summary>
public sealed class RichBlockList : RichBlock
{
    /// <inheritdoc/>
    public override RichBlockType Type => RichBlockType.List;

    /// <summary>Items in the list.</summary>
    public required IReadOnlyList<RichBlockListItem> Items { get; init; }
}

/// <summary>A block quotation.</summary>
public sealed class RichBlockBlockQuotation : RichBlock
{
    /// <inheritdoc/>
    public override RichBlockType Type => RichBlockType.Blockquote;

    /// <summary>Content of the quotation.</summary>
    public required IReadOnlyList<RichBlock> Blocks { get; init; }

    /// <summary>Optional. Credit displayed with the quotation.</summary>
    public RichTextSource? Credit { get; init; }
}

/// <summary>An expandable block quotation.</summary>
public sealed class RichBlockExpandableBlockQuotation : RichBlock
{
    /// <inheritdoc/>
    public override RichBlockType Type => RichBlockType.ExpandableBlockquote;

    /// <summary>Content of the quotation.</summary>
    public required RichText Text { get; init; }

    /// <summary>Optional. Credit displayed with the quotation.</summary>
    public RichText? Credit { get; init; }
}

/// <summary>A centered pull quotation.</summary>
public sealed class RichBlockPullQuotation : RichBlock
{
    /// <inheritdoc/>
    public override RichBlockType Type => RichBlockType.Pullquote;

    /// <summary>Text of the quotation.</summary>
    public required RichTextSource Text { get; init; }

    /// <summary>Optional. Credit displayed with the quotation.</summary>
    public RichTextSource? Credit { get; init; }
}

/// <summary>A collage of rich blocks.</summary>
public sealed class RichBlockCollage : RichBlock
{
    /// <inheritdoc/>
    public override RichBlockType Type => RichBlockType.Collage;

    /// <summary>Elements of the collage.</summary>
    public required IReadOnlyList<RichBlock> Blocks { get; init; }

    /// <summary>Optional. Caption of the collage.</summary>
    public RichBlockCaption? Caption { get; init; }
}

/// <summary>A slideshow of rich blocks.</summary>
public sealed class RichBlockSlideshow : RichBlock
{
    /// <inheritdoc/>
    public override RichBlockType Type => RichBlockType.Slideshow;

    /// <summary>Elements of the slideshow.</summary>
    public required IReadOnlyList<RichBlock> Blocks { get; init; }

    /// <summary>Optional. Caption of the slideshow.</summary>
    public RichBlockCaption? Caption { get; init; }
}

/// <summary>A table in a rich message.</summary>
public sealed class RichBlockTable : RichBlock
{
    /// <inheritdoc/>
    public override RichBlockType Type => RichBlockType.Table;

    /// <summary>Rows and cells of the table.</summary>
    public required IReadOnlyList<IReadOnlyList<RichBlockTableCell>> Cells { get; init; }

    /// <summary>Optional. Indicates whether the table has borders.</summary>
    public bool? IsBordered { get; init; }

    /// <summary>Optional. Indicates whether the table has striped rows.</summary>
    public bool? IsStriped { get; init; }

    /// <summary>Optional. Indicates whether table cells use smaller indents.</summary>
    public bool? IsCompact { get; init; }

    /// <summary>Optional. Caption of the table.</summary>
    public RichTextSource? Caption { get; init; }
}

/// <summary>An expandable details block.</summary>
public sealed class RichBlockDetails : RichBlock
{
    /// <inheritdoc/>
    public override RichBlockType Type => RichBlockType.Details;

    /// <summary>Always-visible summary of the block.</summary>
    public required RichTextSource Summary { get; init; }

    /// <summary>Content revealed by the details block.</summary>
    public required IReadOnlyList<RichBlock> Blocks { get; init; }

    /// <summary>Optional. Indicates whether the content is visible by default.</summary>
    public bool? IsOpen { get; init; }
}

/// <summary>A map block.</summary>
public sealed class RichBlockMap : RichBlock
{
    /// <inheritdoc/>
    public override RichBlockType Type => RichBlockType.Map;

    /// <summary>Center location of the map.</summary>
    public required Location Location { get; init; }

    /// <summary>Map zoom level.</summary>
    public required int Zoom { get; init; }

    /// <summary>Map width.</summary>
    public required int Width { get; init; }

    /// <summary>Map height.</summary>
    public required int Height { get; init; }

    /// <summary>Optional. Caption of the map.</summary>
    public RichBlockCaption? Caption { get; init; }
}

/// <summary>A row of buttons in a rich message.</summary>
public sealed class RichBlockButtons : RichBlock
{
    /// <inheritdoc/>
    public override RichBlockType Type => RichBlockType.Buttons;

    /// <summary>Buttons in the row.</summary>
    public required IReadOnlyList<RichMessageButton> Buttons { get; init; }

    /// <summary>Optional. Horizontal alignment of the buttons.</summary>
    public RichBlockButtonsAlign? Align { get; init; }
}

/// <summary>An animation media block.</summary>
public sealed class RichBlockAnimation : RichBlock
{
    /// <inheritdoc/>
    public override RichBlockType Type => RichBlockType.Animation;

    /// <summary>Animation in the block.</summary>
    public required Animation Animation { get; init; }

    /// <summary>Optional. Indicates whether the animation is covered by a spoiler.</summary>
    public bool? HasSpoiler { get; init; }

    /// <summary>Optional. Caption of the animation.</summary>
    public RichBlockCaption? Caption { get; init; }
}

/// <summary>An audio media block.</summary>
public sealed class RichBlockAudio : RichBlock
{
    /// <inheritdoc/>
    public override RichBlockType Type => RichBlockType.Audio;

    /// <summary>Audio in the block.</summary>
    public required Audio Audio { get; init; }

    /// <summary>Optional. Caption of the audio.</summary>
    public RichBlockCaption? Caption { get; init; }
}

/// <summary>A document media block.</summary>
public sealed class RichBlockDocument : RichBlock
{
    /// <inheritdoc/>
    public override RichBlockType Type => RichBlockType.Document;

    /// <summary>Document in the block.</summary>
    public required Document Document { get; init; }

    /// <summary>Optional. Caption of the document.</summary>
    public RichBlockCaption? Caption { get; init; }
}

/// <summary>A photo media block.</summary>
public sealed class RichBlockPhoto : RichBlock
{
    /// <inheritdoc/>
    public override RichBlockType Type => RichBlockType.Photo;

    /// <summary>Photo sizes available for the block.</summary>
    public required IReadOnlyList<PhotoSize> Photo { get; init; }

    /// <summary>Optional. Indicates whether the photo is covered by a spoiler.</summary>
    public bool? HasSpoiler { get; init; }

    /// <summary>Optional. Caption of the photo.</summary>
    public RichBlockCaption? Caption { get; init; }
}

/// <summary>A video media block.</summary>
public sealed class RichBlockVideo : RichBlock
{
    /// <inheritdoc/>
    public override RichBlockType Type => RichBlockType.Video;

    /// <summary>Video in the block.</summary>
    public required Video Video { get; init; }

    /// <summary>Optional. Indicates whether the video is covered by a spoiler.</summary>
    public bool? HasSpoiler { get; init; }

    /// <summary>Optional. Caption of the video.</summary>
    public RichBlockCaption? Caption { get; init; }
}

/// <summary>A voice note media block.</summary>
public sealed class RichBlockVoiceNote : RichBlock
{
    /// <inheritdoc/>
    public override RichBlockType Type => RichBlockType.VoiceNote;

    /// <summary>Voice note in the block.</summary>
    public required Voice VoiceNote { get; init; }

    /// <summary>Optional. Caption of the voice note.</summary>
    public RichBlockCaption? Caption { get; init; }
}

/// <summary>A “Thinking...” placeholder block used in streamed rich message drafts.</summary>
public sealed class RichBlockThinking : RichBlock
{
    /// <inheritdoc/>
    public override RichBlockType Type => RichBlockType.Thinking;

    /// <summary>Text displayed in the placeholder.</summary>
    public required RichTextSource Text { get; init; }
}
