namespace Telegram.BotAPI.Types.AvailableTypes;

public sealed class ChatBoostRemoved
{
    public Chat Chat { get; set; }

    public string BoostId { get; set; }

    public int RemoveDate { get; set; }

    public ChatBoostSource Source { get; set; }
}
