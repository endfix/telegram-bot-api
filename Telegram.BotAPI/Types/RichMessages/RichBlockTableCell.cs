using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Describes a cell in a rich message table.</summary>
public sealed class RichBlockTableCell
{
    /// <summary>Optional. Text contained in the cell.</summary>
    public RichTextSource? Text { get; init; }

    /// <summary>Optional. Indicates whether the cell is a header.</summary>
    public bool? IsHeader { get; init; }

    /// <summary>Optional. Number of columns spanned by the cell.</summary>
    public int? Colspan { get; init; }

    /// <summary>Optional. Number of rows spanned by the cell.</summary>
    public int? Rowspan { get; init; }

    /// <summary>Horizontal alignment of the cell.</summary>
    public required RichBlockTableCellAlign Align { get; init; }

    /// <summary>Vertical alignment of the cell.</summary>
    public required RichBlockTableCellVAlign Valign { get; init; }
}
