namespace Telegram.BotAPI.Parameters;

public sealed class RemoveUserVerificationParameters : ApiRequestParameters
{
    public long UserId { get; set; }
}
