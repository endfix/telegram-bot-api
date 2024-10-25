namespace Telegram.BotAPI.Types;

// https://core.telegram.org/bots/api#chatboostupdated
public sealed class ChatBoostUpdated
{
    public Chat Chat { get; set; }

    public ChatBoost Boost { get; set; }
}
