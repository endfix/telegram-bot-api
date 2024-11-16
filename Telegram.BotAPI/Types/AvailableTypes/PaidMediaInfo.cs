using System.Collections.Generic;

namespace Telegram.BotAPI.Types.AvailableTypes;

public sealed class PaidMediaInfo
{
    public int StarCount { get; set; }

    public List<PaidMedia> PaidMedia { get; set; }
}
