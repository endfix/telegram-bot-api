using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

public sealed class OwnedGifts
{
    public required int TotalCount { get; init; }

    public required IReadOnlyList<OwnedGift> Gifts { get; init; }
    
    public string? NextOffset { get; init; }
}
