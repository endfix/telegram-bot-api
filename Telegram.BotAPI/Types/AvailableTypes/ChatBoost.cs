namespace Telegram.BotAPI.Types.AvailableTypes;

public sealed class ChatBoost
{
    public string BoostId { get; set; }

    public int AddDate { get; set; }

    public int ExpirationDate { get; set; }

    public ChatBoostSource Source { get; set; }
}
