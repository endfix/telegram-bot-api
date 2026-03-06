namespace Telegram.BotAPI.Parameters;

public sealed class RemoveUserVerificationParameters : ApiRequestParameters
{
    public required long UserId { get; init; }
}
