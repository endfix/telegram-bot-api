using System.Collections.Generic;

namespace Telegram.BotAPI.Types.AvailableTypes;

public sealed class BusinessOpeningHours
{
    public string TimeZoneName { get; set; }

    public List<BusinessOpeningHoursInterval> OpeningHours { get; set; }
}
