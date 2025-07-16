namespace Telegram.BotAPI.Types;

public sealed class ResponseParameters
{
    public int MigrateToChatId { get; set; }

    public int RetryAfter { get; set; }
}
