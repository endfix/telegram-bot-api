using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>createInvoiceLink</c> method.
/// </summary>
public sealed class CreateInvoiceLinkParameters : ApiRequestParameters
{
    /// <summary>Unique identifier of the business connection.</summary>
    public string? BusinessConnectionId { get; init; }

    /// <summary>Product name, 1-32 characters.</summary>
    public required string Title { get; init; }

    /// <summary>Product description, 1-255 characters.</summary>
    public required string Description { get; init; }

    /// <summary>Bot-defined invoice payload, 1-128 bytes.</summary>
    public required string Payload { get; init; }

    /// <summary>Payment provider token. Not required for Telegram Stars.</summary>
    public string? ProviderToken { get; init; }

    /// <summary>Three-letter ISO 4217 currency code.</summary>
    public required string Currency { get; init; }

    /// <summary>Price breakdown in the smallest units of the currency.</summary>
    public required IReadOnlyList<LabeledPrice> Prices { get; init; }

    /// <summary>Subscription period in seconds; currently 2592000 seconds (30 days).</summary>
    public int? SubscriptionPeriod { get; init; }

    /// <summary>Maximum tip amount in the smallest units of the currency.</summary>
    public int? MaxTipAmount { get; init; }

    /// <summary>Suggested tip amounts in the smallest units of the currency.</summary>
    public IReadOnlyList<int>? SuggestedTipAmounts { get; init; }

    /// <summary>JSON-encoded data for the payment provider.</summary>
    public string? ProviderData { get; init; }

    /// <summary>Product photo URL.</summary>
    public string? PhotoUrl { get; init; }

    /// <summary>Photo size in bytes.</summary>
    public int? PhotoSize { get; init; }

    /// <summary>Photo width.</summary>
    public int? PhotoWidth { get; init; }

    /// <summary>Photo height.</summary>
    public int? PhotoHeight { get; init; }

    /// <summary>Whether to request the user's full name.</summary>
    public bool? NeedName { get; init; }

    /// <summary>Whether to request the user's phone number.</summary>
    public bool? NeedPhoneNumber { get; init; }

    /// <summary>Whether to request the user's email address.</summary>
    public bool? NeedEmail { get; init; }

    /// <summary>Whether to request the user's shipping address.</summary>
    public bool? NeedShippingAddress { get; init; }

    /// <summary>Whether to send the user's phone number to the provider.</summary>
    public bool? SendPhoneNumberToProvider { get; init; }

    /// <summary>Whether to send the user's email address to the provider.</summary>
    public bool? SendEmailToProvider { get; init; }

    /// <summary>Whether the final price depends on the shipping method.</summary>
    public bool? IsFlexible { get; init; }
}
