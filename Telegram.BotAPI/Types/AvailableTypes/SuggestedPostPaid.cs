namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Describes a service message about a successful payment for a suggested post.
/// </summary>
public sealed class SuggestedPostPaid
{
    /// <summary>Optional message containing the suggested post.</summary>
    public Message? SuggestedPostMessage { get; init; }

    /// <summary>Currency in which the payment was made: XTR for Telegram Stars or TON for TON grams.</summary>
    public required string Currency { get; init; }

    /// <summary>Optional amount of TON received by the channel, in nanograms.</summary>
    public int? Amount { get; init; }

    /// <summary>Optional amount of Telegram Stars received by the channel.</summary>
    public StarAmount? StarAmount { get; init; }
}
