using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

public sealed class BusinessOpeningHours
{
    public required string TimeZoneName { get; init; }

    public required IReadOnlyList<BusinessOpeningHoursInterval> OpeningHours { get; init; }
}
