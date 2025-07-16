namespace Telegram.BotAPI.Types;

public sealed class BusinessOpeningHours
{
    public string TimeZoneName { get; set; }

    public BusinessOpeningHoursInterval[] OpeningHours { get; set; }
}
