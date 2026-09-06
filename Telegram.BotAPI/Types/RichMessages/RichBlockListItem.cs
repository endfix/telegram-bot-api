using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Represents an item in a rich message list.
/// </summary>
public sealed class RichBlockListItem
{
    /// <summary>Label of the list item.</summary>
    public required string Label { get; init; }

    /// <summary>Blocks contained in the list item.</summary>
    public required IReadOnlyList<RichBlock> Blocks { get; init; }

    /// <summary>True if the item displays a checkbox.</summary>
    public bool? HasCheckbox { get; init; }

    /// <summary>True if the item's checkbox is checked.</summary>
    public bool? IsChecked { get; init; }
    
    /// <summary>Optional numeric value associated with the item.</summary>
    public int? Value { get; init; }

    /// <summary>Optional list item type.</summary>
    public string? Type { get; init; }
}
