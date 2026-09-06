using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Describes the opening hours of a business.</summary>
public sealed class BusinessOpeningHours
{
    /// <summary>Unique name of the time zone for which the opening hours are defined.</summary>
    public required string TimeZoneName { get; init; }

    /// <summary>List of opening-hour intervals.</summary>
    public required IReadOnlyList<BusinessOpeningHoursInterval> OpeningHours { get; init; }
}
