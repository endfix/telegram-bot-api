namespace Telegram.BotAPI.Parameters;

public sealed class SetBusinessAccountBioParameters : ApiRequestParameters
{
    public string BusinessConnectionId { get; set; }

    public string Bio { get; set; }
}
