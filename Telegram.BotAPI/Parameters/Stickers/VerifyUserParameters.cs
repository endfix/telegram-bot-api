namespace Telegram.BotAPI.Parameters;

public sealed class VerifyUserParameters : ApiRequestParameters
{
    public long UserId { get; set; }

    public string CustomDescription { get; set; }
}
