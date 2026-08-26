using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

public sealed class RichBlockListItem
{
    public required string Label { get; init; }

    public required IReadOnlyList<RichBlock> Blocks { get; init; }

    public bool? HasCheckbox { get; init; }

    public bool? IsChecked { get; init; }
    
    public int? Value { get; init; }

    public string? Type { get; init; }
}
