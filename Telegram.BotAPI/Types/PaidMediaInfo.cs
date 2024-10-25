using System.Collections.Generic;

namespace Telegram.BotAPI.Types
{
    // https://core.telegram.org/bots/api#paidmediainfo
    public sealed class PaidMediaInfo
    {
        public int StarCount { get; set; }

        public List<PaidMedia> PaidMedia { get; set; }
    }
}
