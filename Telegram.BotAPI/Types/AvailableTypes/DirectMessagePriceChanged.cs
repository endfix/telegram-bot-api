namespace Telegram.BotAPI.Types;

public sealed class DirectMessagePriceChanged
{
    public required bool AreDirectMessagesEnabled { get; init; }

    public int? DirectMessageStarCount { get; init; }
}
