namespace Telegram.BotAPI.Parameters;

public sealed class SetBusinessAccountUsernameParameters : ApiRequestParameters
{
    public string BusinessConnectionId { get; set; }

    public string Username { get; set; }
}
