namespace Telegram.BotAPI.Types;

public sealed class DirectMessagePriceChanged
{
    public bool AreDirectMessagesEnabled { get; set; }

    public int DirectMessageStarCount { get; set; }
}
