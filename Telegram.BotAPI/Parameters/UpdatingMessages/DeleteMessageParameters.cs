namespace Telegram.BotAPI.Parameters;

public sealed class DeleteMessageParameters : ApiRequestParameters
{
    public required object ChatId { get; init; }

    public required long MessageId { get; init; }
}
