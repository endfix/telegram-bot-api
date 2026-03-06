namespace Telegram.BotAPI.Parameters;

public sealed class UnpinChatMessageParameters : ApiRequestParameters
{
    public string? BusinessConnectionId { get; init; }

    public required object ChatId { get; init; }

    public int? MessageId { get; init; }
}
