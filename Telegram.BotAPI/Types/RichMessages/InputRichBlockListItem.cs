using System.Collections.Generic;

namespace Telegram.BotAPI.Types;

public sealed class InputRichBlockListItem
{
    public required IReadOnlyList<InputRichBlock> Blocks { get; init; }

    public bool? HasCheckbox { get; init; }

    public bool? IsChecked { get; init; }

    public int? Value { get; init; }

    public string? Type { get; init; }
}
