namespace Telegram.BotAPI.Types;

public sealed class ChatBoostUpdated
{
    public Chat Chat { get; set; }

    public ChatBoost Boost { get; set; }
}
