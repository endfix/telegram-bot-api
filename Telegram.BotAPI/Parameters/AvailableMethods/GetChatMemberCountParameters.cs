namespace Telegram.BotAPI.Parameters;

public sealed class GetChatMemberCountParameters : ApiRequestParameters
{
    public required object ChatId { get; init; }
}
