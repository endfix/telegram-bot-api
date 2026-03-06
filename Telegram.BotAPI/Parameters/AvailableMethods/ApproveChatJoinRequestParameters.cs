namespace Telegram.BotAPI.Parameters;

public sealed class ApproveChatJoinRequestParameters : ApiRequestParameters
{
    public required object ChatId { get; init; }

    public required long UserId { get; init; }
}
