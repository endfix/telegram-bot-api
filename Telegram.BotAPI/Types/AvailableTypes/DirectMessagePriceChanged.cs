namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Describes a change in the price of direct messages sent to a channel.</summary>
public sealed class DirectMessagePriceChanged
{
    /// <summary>Indicates whether direct messages are enabled for the channel.</summary>
    public required bool AreDirectMessagesEnabled { get; init; }

    /// <summary>Optional. Number of Telegram Stars users must pay for each direct message sent to the channel.</summary>
    public int? DirectMessageStarCount { get; init; }
}
