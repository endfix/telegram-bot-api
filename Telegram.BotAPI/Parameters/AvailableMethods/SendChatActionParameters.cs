namespace Telegram.BotAPI.Parameters;

public sealed class SendChatActionParameters : ApiRequestParameters
{
    public string? BusinessConnectionId { get; init; }

    public required object ChatId { get; init; }

    public int? MessageThreadId { get; init; }

    public required string Action { get; init; }
}
