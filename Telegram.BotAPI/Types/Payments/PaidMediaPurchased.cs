namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Describes paid media purchased by a user.</summary>
public sealed class PaidMediaPurchased
{
    /// <summary>The user who purchased the paid media.</summary>
    public required User From { get; init; }

    /// <summary>Bot-defined payload that identifies the purchased paid media.</summary>
    public required string PaidMediaPayload { get; init; }
}
