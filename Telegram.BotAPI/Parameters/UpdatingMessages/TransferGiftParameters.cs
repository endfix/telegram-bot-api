namespace Telegram.BotAPI.Parameters;

public sealed class TransferGiftParameters : ApiRequestParameters
{
    public string BusinessConnectionId { get; set; }

    public string OwnedGiftId { get; set; }

    public int NewOwnerChatId { get; set; }

    public int StarCount { get; set; }
}
