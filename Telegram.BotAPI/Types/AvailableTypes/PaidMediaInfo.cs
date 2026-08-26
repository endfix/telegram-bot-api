using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

public sealed class PaidMediaInfo
{
    public required int StarCount { get; init; }

    public required IReadOnlyList<PaidMedia> PaidMedia { get; init; }
}
