using System;
using System.Collections.Generic;
using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

public abstract class InputRichBlock
{
    public abstract InputRichBlockType Type { get; }
}

public sealed class InputRichBlockParagraph : InputRichBlock
{
    public override InputRichBlockType Type => InputRichBlockType.Paragraph;

    public required RichText Text { get; init; }
}

public sealed class InputRichBlockSectionHeading : InputRichBlock
{
    public override InputRichBlockType Type => InputRichBlockType.Heading;

    public required RichText Text { get; init; }

    public required int Size { get; init; }
}

public sealed class InputRichBlockPreformatted : InputRichBlock
{
    public override InputRichBlockType Type => InputRichBlockType.Pre;

    public required RichText Text { get; init; }

    public string? Language { get; init; }
}

public sealed class InputRichBlockFooter : InputRichBlock
{
    public override InputRichBlockType Type => InputRichBlockType.Footer;

    public required RichText Text { get; init; }
}

public sealed class InputRichBlockDivider : InputRichBlock
{
    public override InputRichBlockType Type => InputRichBlockType.Divider;
}

public sealed class InputRichBlockMathematicalExpression : InputRichBlock
{
    public override InputRichBlockType Type => InputRichBlockType.MathematicalExpression;

    public required string Expression { get; init; }
}

public sealed class InputRichBlockAnchor : InputRichBlock
{
    public override InputRichBlockType Type => InputRichBlockType.Anchor;

    public required string Name { get; init; }
}

public sealed class InputRichBlockList : InputRichBlock
{
    public override InputRichBlockType Type => InputRichBlockType.List;

    public required IReadOnlyList<InputRichBlockListItem> Items { get; init; }
}

public sealed class InputRichBlockBlockQuotation : InputRichBlock
{
    public override InputRichBlockType Type => InputRichBlockType.Blockquote;

    public required IReadOnlyList<InputRichBlock> Blocks { get; init; }

    public RichText? Credit { get; init; }
}

public sealed class InputRichBlockExpandableBlockQuotation : InputRichBlock
{
    public override InputRichBlockType Type => InputRichBlockType.ExpandableBlockquote;

    public required RichText Text { get; init; }

    public RichText? Credit { get; init; }
}

public sealed class InputRichBlockPullQuotation : InputRichBlock
{
    public override InputRichBlockType Type => InputRichBlockType.Pullquote;

    public required RichText Text { get; init; }

    public RichText? Credit { get; init; }
}

public sealed class InputRichBlockCollage : InputRichBlock
{
    public override InputRichBlockType Type => InputRichBlockType.Collage;

    public required IReadOnlyList<InputRichBlock> Blocks { get; init; }

    public RichBlockCaption? Caption { get; init; }
}

public sealed class InputRichBlockSlideshow : InputRichBlock
{
    public override InputRichBlockType Type => InputRichBlockType.Slideshow;

    public required IReadOnlyList<InputRichBlock> Blocks { get; init; }

    public RichBlockCaption? Caption { get; init; }
}

public sealed class InputRichBlockTable : InputRichBlock
{
    public override InputRichBlockType Type => InputRichBlockType.Table;

    public required IReadOnlyList<IReadOnlyList<RichBlockTableCell>> Cells { get; init; }

    public bool? IsBordered { get; init; }

    public bool? IsStriped { get; init; }

    public bool? IsCompact { get; init; }

    public RichText? Caption { get; init; }
}

public sealed class InputRichBlockDetails : InputRichBlock
{
    public override InputRichBlockType Type => InputRichBlockType.Details;

    public required RichText Summary { get; init; }

    public required IReadOnlyList<InputRichBlock> Blocks { get; init; }

    public bool? IsOpen { get; init; }
}

public sealed class InputRichBlockMap : InputRichBlock
{
    public override InputRichBlockType Type => InputRichBlockType.Map;

    public required Location Location { get; init; }

    public required int Zoom { get; init; }

    public required int Width { get; init; }

    public required int Height { get; init; }

    public RichBlockCaption? Caption { get; init; }
}

public sealed class InputRichBlockButtons : InputRichBlock
{
    public override InputRichBlockType Type => InputRichBlockType.Buttons;

    public required IReadOnlyList<RichMessageButton> Buttons { get; init; }

    public InputRichBlockButtonsAlign? Align { get; init; }
}

public sealed class InputRichBlockAnimation : InputRichBlock
{
    public override InputRichBlockType Type => InputRichBlockType.Animation;

    public required InputMediaAnimation Animation { get; init; }

    public RichBlockCaption? Caption { get; init; }
}

public sealed class InputRichBlockAudio : InputRichBlock
{
    public override InputRichBlockType Type => InputRichBlockType.Audio;

    public required InputMediaAudio Audio { get; init; }

    public RichBlockCaption? Caption { get; init; }
}

public sealed class InputRichBlockDocument : InputRichBlock
{
    public override InputRichBlockType Type => InputRichBlockType.Document;

    public required InputMediaDocument Document { get; init; }

    public RichBlockCaption? Caption { get; init; }
}

public sealed class InputRichBlockPhoto : InputRichBlock
{
    public override InputRichBlockType Type => InputRichBlockType.Photo;

    public required InputMediaPhoto Photo { get; init; }

    public RichBlockCaption? Caption { get; init; }
}

public sealed class InputRichBlockVideo : InputRichBlock
{
    public override InputRichBlockType Type => InputRichBlockType.Video;

    public required InputMediaVideo Video { get; init; }

    public RichBlockCaption? Caption { get; init; }
}

public sealed class InputRichBlockVoiceNote : InputRichBlock
{
    public override InputRichBlockType Type => InputRichBlockType.VoiceNote;

    public required InputMediaVoiceNote VoiceNote { get; init; }

    public RichBlockCaption? Caption { get; init; }
}

public sealed class InputRichBlockThinking : InputRichBlock
{
    public override InputRichBlockType Type => InputRichBlockType.Thinking;

    public required RichText Text { get; init; }
}
