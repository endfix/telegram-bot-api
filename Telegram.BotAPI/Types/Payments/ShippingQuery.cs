namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Represents an incoming shipping query.</summary>
public sealed class ShippingQuery
{
    /// <summary>Unique identifier for this query.</summary>
    public required string Id { get; init; }

    /// <summary>Sender of the query.</summary>
    public required User From { get; init; }

    /// <summary>Bot-defined invoice payload.</summary>
    public required string InvoicePayload { get; init; }

    /// <summary>User's shipping address.</summary>
    public required ShippingAddress ShippingAddress { get; init; }
}
