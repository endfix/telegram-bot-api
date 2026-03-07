using System.Collections.Generic;

namespace Telegram.BotAPI.Types;

public sealed class BusinessOpeningHours
{
    public required string TimeZoneName { get; init; }

    public required IReadOnlyList<BusinessOpeningHoursInterval> OpeningHours { get; init; }
}
