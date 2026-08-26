using System;
using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

public abstract class RichBlock
{
    public abstract RichBlockType Type { get; }
}

public sealed class RichBlockParagraph : RichBlock
{
    public override RichBlockType Type => RichBlockType.Paragraph;

    public required RichTextSource Text { get; init; }
}

public sealed class RichBlockSectionHeading : RichBlock
{
    public override RichBlockType Type => RichBlockType.Heading;

    public required RichTextSource Text { get; init; }

    public required int Size { get; init; }
}

public sealed class RichBlockPreformatted : RichBlock
{
    public override RichBlockType Type => RichBlockType.Pre;

    public required RichTextSource Text { get; init; }

    public string? Language { get; init; }
}

public sealed class RichBlockFooter : RichBlock
{
    public override RichBlockType Type => RichBlockType.Footer;

    public required RichTextSource Text { get; init; }
}

public sealed class RichBlockDivider : RichBlock
{
    public override RichBlockType Type => RichBlockType.Divider;
}

public sealed class RichBlockMathematicalExpression : RichBlock
{
    public override RichBlockType Type => RichBlockType.MathematicalExpression;

    public required string Expression { get; init; }
}

public sealed class RichBlockAnchor : RichBlock
{
    public override RichBlockType Type => RichBlockType.Anchor;

    public required string Name { get; init; }
}

public sealed class RichBlockList : RichBlock
{
    public override RichBlockType Type => RichBlockType.List;

    public required IReadOnlyList<RichBlockListItem> Items { get; init; }
}

public sealed class RichBlockBlockQuotation : RichBlock
{
    public override RichBlockType Type => RichBlockType.Blockquote;

    public required IReadOnlyList<RichBlock> Blocks { get; init; }

    public RichTextSource? Credit { get; init; }
}

public sealed class RichBlockExpandableBlockQuotation : RichBlock
{
    public override RichBlockType Type => RichBlockType.ExpandableBlockquote;

    public required RichText Text { get; init; }

    public RichText? Credit { get; init; }
}

public sealed class RichBlockPullQuotation : RichBlock
{
    public override RichBlockType Type => RichBlockType.Pullquote;

    public required RichTextSource Text { get; init; }

    public RichTextSource? Credit { get; init; }
}

public sealed class RichBlockCollage : RichBlock
{
    public override RichBlockType Type => RichBlockType.Collage;

    public required IReadOnlyList<RichBlock> Blocks { get; init; }

    public RichBlockCaption? Caption { get; init; }
}

public sealed class RichBlockSlideshow : RichBlock
{
    public override RichBlockType Type => RichBlockType.Slideshow;

    public required IReadOnlyList<RichBlock> Blocks { get; init; }

    public RichBlockCaption? Caption { get; init; }
}

public sealed class RichBlockTable : RichBlock
{
    public override RichBlockType Type => RichBlockType.Table;

    public required IReadOnlyList<IReadOnlyList<RichBlockTableCell>> Cells { get; init; }

    public bool? IsBordered { get; init; }

    public bool? IsStriped { get; init; }

    public bool? IsCompact { get; init; }

    public RichTextSource? Caption { get; init; }
}

public sealed class RichBlockDetails : RichBlock
{
    public override RichBlockType Type => RichBlockType.Details;

    public required RichTextSource Summary { get; init; }

    public required IReadOnlyList<RichBlock> Blocks { get; init; }

    public bool? IsOpen { get; init; }
}

public sealed class RichBlockMap : RichBlock
{
    public override RichBlockType Type => RichBlockType.Map;

    public required Location Location { get; init; }

    public required int Zoom { get; init; }

    public required int Width { get; init; }

    public required int Height { get; init; }

    public RichBlockCaption? Caption { get; init; }
}

public sealed class RichBlockButtons : RichBlock
{
    public override RichBlockType Type => RichBlockType.Buttons;

    public required IReadOnlyList<RichMessageButton> Buttons { get; init; }

    public RichBlockButtonsAlign? Align { get; init; }
}

public sealed class RichBlockAnimation : RichBlock
{
    public override RichBlockType Type => RichBlockType.Animation;

    public required Animation Animation { get; init; }

    public bool? HasSpoiler { get; init; }

    public RichBlockCaption? Caption { get; init; }
}

public sealed class RichBlockAudio : RichBlock
{
    public override RichBlockType Type => RichBlockType.Audio;

    public required Audio Audio { get; init; }

    public RichBlockCaption? Caption { get; init; }
}

public sealed class RichBlockDocument : RichBlock
{
    public override RichBlockType Type => RichBlockType.Document;

    public required Document Document { get; init; }

    public RichBlockCaption? Caption { get; init; }
}

public sealed class RichBlockPhoto : RichBlock
{
    public override RichBlockType Type => RichBlockType.Photo;

    public required IReadOnlyList<PhotoSize> Photos { get; init; }

    public bool? HasSpoiler { get; init; }

    public RichBlockCaption? Caption { get; init; }
}

public sealed class RichBlockVideo : RichBlock
{
    public override RichBlockType Type => RichBlockType.Video;

    public required Video Video { get; init; }

    public bool? HasSpoiler { get; init; }

    public RichBlockCaption? Caption { get; init; }
}

public sealed class RichBlockVoiceNote : RichBlock
{
    public override RichBlockType Type => RichBlockType.VoiceNote;

    public required Voice VoiceNote { get; init; }

    public RichBlockCaption? Caption { get; init; }
}

public sealed class RichBlockThinking : RichBlock
{
    public override RichBlockType Type => RichBlockType.Thinking;

    public required RichTextSource Text { get; init; }
}
