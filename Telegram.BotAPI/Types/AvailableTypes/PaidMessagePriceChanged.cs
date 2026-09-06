namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Describes a service message about a change in the price of paid messages in a chat.</summary>
public sealed class PaidMessagePriceChanged
{
    /// <summary>Number of Telegram Stars users must pay for each message.</summary>
    public required int PaidMessageStarCount { get; init; }
}
