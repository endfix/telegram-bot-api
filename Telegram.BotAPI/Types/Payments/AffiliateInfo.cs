namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Contains information about the affiliate that received a commission via this transaction.</summary>
public sealed class AffiliateInfo
{
    /// <summary>The bot or user that received the affiliate commission, if it was received by a bot or a user.</summary>
    public User? AffiliateUser { get; init; }

    /// <summary>The chat that received the affiliate commission, if it was received by a chat.</summary>
    public Chat? AffiliateChat { get; init; }

    /// <summary>The number of Telegram Stars received by the affiliate for each 1000 Telegram Stars received by the bot from referred users.</summary>
    public required int CommissionPerMille { get; init; }

    /// <summary>The integer amount of Telegram Stars received by the affiliate from the transaction, rounded to 0; can be negative for refunds.</summary>
    public required int Amount { get; init; }

    /// <summary>The number of 1/100000000 shares of Telegram Stars received by the affiliate, if supplied; can be negative for refunds.</summary>
    public int? NanostarAmount { get; init; }
}
