using System.Collections.Generic;

namespace Telegram.BotAPI.Types;

// https://core.telegram.org/bots/api#businessopeninghours
public sealed class BusinessOpeningHours
{
    public string TimeZoneName { get; set; }

    public List<BusinessOpeningHoursInterval> OpeningHours { get; set; }
}
