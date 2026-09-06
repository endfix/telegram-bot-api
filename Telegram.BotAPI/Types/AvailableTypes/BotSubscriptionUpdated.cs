using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Contains information about a change to a user's payment subscription toward the bot.</summary>
public sealed class BotSubscriptionUpdated
{
    /// <summary>User who subscribed to payments toward the bot.</summary>
    public required User User { get; init; }

    /// <summary>Bot-specified invoice payload.</summary>
    public required string InvoicePayload { get; init; }

    /// <summary>New subscription state.</summary>
    public required BotSubscriptionUpdatedState State { get; init; }
}
