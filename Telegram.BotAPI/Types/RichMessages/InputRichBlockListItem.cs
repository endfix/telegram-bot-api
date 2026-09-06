using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Describes an item of a list in an outgoing rich message.</summary>
public sealed class InputRichBlockListItem
{
    /// <summary>Content of the list item.</summary>
    public required IReadOnlyList<InputRichBlock> Blocks { get; init; }

    /// <summary>Optional. Pass <see langword="true"/> if the item has a checkbox.</summary>
    public bool? HasCheckbox { get; init; }

    /// <summary>Optional. Pass <see langword="true"/> if the item's checkbox is checked.</summary>
    public bool? IsChecked { get; init; }

    /// <summary>Optional. Numeric value of the item label in an ordered list.</summary>
    public int? Value { get; init; }

    /// <summary>Optional. Type of the item label in an ordered list: <c>a</c>, <c>A</c>, <c>i</c>, <c>I</c> or <c>1</c>.</summary>
    public string? Type { get; init; }
}
