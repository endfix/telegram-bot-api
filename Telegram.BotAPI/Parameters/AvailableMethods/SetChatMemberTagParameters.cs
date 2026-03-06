namespace Telegram.BotAPI.Parameters;

public sealed class SetChatMemberTagParameters : ApiRequestParameters
{
    public required object ChatId { get; init; }

    public required long UserId { get; init; }

    public string? Tag { get; init; }
}
