namespace Telegram.BotAPI.Protocol;

public sealed class ApiResponseParameters
{
    public long MigrateToChatId { get; set; }

    public int RetryAfter { get; set; }
}
