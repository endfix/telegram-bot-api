namespace Telegram.BotAPI.Parameters;

public sealed class UnbanChatMemberParameters : ApiRequestParameters
{
    public required object ChatId { get; init; }

    public required long UserId { get; init; }

    public bool? OnlyIfBanned { get; init; }
}
