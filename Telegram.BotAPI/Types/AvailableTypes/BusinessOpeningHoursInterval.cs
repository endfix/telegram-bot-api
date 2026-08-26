namespace Endfix.Telegram.BotAPI.Types;

public sealed class BusinessOpeningHoursInterval
{
    public required int OpeningMinute { get; init; }

    public required int ClosingMinute { get; init; }
}
