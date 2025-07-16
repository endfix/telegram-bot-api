namespace Telegram.BotAPI.Parameters;

public sealed class SetBusinessAccountNameParameters : ApiRequestParameters
{
    public string BusinessConnectionId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }
}
