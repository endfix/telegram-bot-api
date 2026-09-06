namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Describes one business opening-hours interval.</summary>
public sealed class BusinessOpeningHoursInterval
{
    /// <summary>Opening minute in the business time zone.</summary>
    public required int OpeningMinute { get; init; }

    /// <summary>Closing minute in the business time zone.</summary>
    public required int ClosingMinute { get; init; }
}
