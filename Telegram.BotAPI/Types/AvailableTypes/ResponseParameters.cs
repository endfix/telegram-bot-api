namespace Endfix.Telegram.BotAPI.Types;

public sealed class ResponseParameters
{
    public long? MigrateToChatId { get; init; }

    public int? RetryAfter { get; init; }
}
