namespace Telegram.BotAPI.Types;

// https://core.telegram.org/bots/api#businessopeninghoursinterval
public sealed class BusinessOpeningHoursInterval
{
    public int OpeningMinute { get; set; }

    public int ClosingMinute { get; set; }
}
