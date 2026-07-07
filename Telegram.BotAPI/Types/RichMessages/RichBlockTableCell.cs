using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

public sealed class RichBlockTableCell
{
    public RichText? Text { get; init; }

    public bool? IsHeader { get; init; }

    public int? Colspan { get; init; }

    public int? Rowspan { get; init; }

    public required RichBlockTableCellAlign Align { get; init; }

    public required RichBlockTableCellVAlign? Valign { get; init; }
}
