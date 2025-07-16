namespace Telegram.BotAPI.Parameters;

public sealed class TransferBusinessAccountStarsParameters : ApiRequestParameters
{
    public string BusinessConnectionId { get; set; }

    public int StarCount { get; set; }
}
