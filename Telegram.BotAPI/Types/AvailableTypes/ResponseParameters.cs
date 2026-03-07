namespace Telegram.BotAPI.Types;

public sealed class ResponseParameters
{
    public int? MigrateToChatId { get; init; }

    public int? RetryAfter { get; init; }
}
