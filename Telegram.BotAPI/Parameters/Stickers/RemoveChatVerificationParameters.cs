namespace Telegram.BotAPI.Parameters;

public sealed class RemoveChatVerificationParameters : ApiRequestParameters
{
    public required object ChatId { get; init; }
}
