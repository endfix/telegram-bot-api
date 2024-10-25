namespace Telegram.BotAPI.Types;

// https://core.telegram.org/bots/api#responseparameters
public sealed class ResponseParameters
{
    public int MigrateToChatId { get; set; }

    public int RetryAfter { get; set; }
}
