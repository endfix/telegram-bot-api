using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Base type for content sent as the result of an inline query.</summary>
public abstract class InputMessageContent
{
    //
}

/// <summary>Describes text message content for an inline result.</summary>
public sealed class InputTextMessageContent : InputMessageContent
{
    /// <summary>Text of the message to send.</summary>
    public required string MessageText { get; init; }

    /// <summary>Mode used to parse entities in the message text.</summary>
    public string? ParseMode { get; init; }

    /// <summary>Explicit entities in the message text.</summary>
    public IReadOnlyList<MessageEntity>? Entities { get; init; }

    /// <summary>Link preview generation options.</summary>
    public LinkPreviewOptions? LinkPreviewOptions { get; init; }
}

/// <summary>Describes rich message content for an inline result.</summary>
public sealed class InputRichMessageContent : InputMessageContent
{
    /// <summary>Rich message to send.</summary>
    public required InputRichMessage RichMessage { get; init; }
}

/// <summary>Describes location message content for an inline result.</summary>
public sealed class InputLocationMessageContent : InputMessageContent
{
    /// <summary>Latitude of the location in degrees.</summary>
    public required double Latitude { get; init; }

    /// <summary>Longitude of the location in degrees.</summary>
    public required double Longitude { get; init; }

    /// <summary>Radius of uncertainty for the location in meters; 0-1500.</summary>
    public float? HorizontalAccuracy { get; init; }

    /// <summary>Period in seconds during which the location can be updated; 60-86400, or <see cref="int.MaxValue"/> for indefinite editing.</summary>
    public int? LivePeriod { get; init; }

    /// <summary>Direction in which the user is moving, in degrees; 1-360 for live locations.</summary>
    public int? Heading { get; init; }

    /// <summary>Maximum distance in meters for proximity alerts about another chat member; 1-100000 for live locations.</summary>
    public int? ProximityAlertRadius { get; init; }
}

/// <summary>Describes venue message content for an inline result.</summary>
public sealed class InputVenueMessageContent : InputMessageContent
{
    /// <summary>Latitude of the venue in degrees.</summary>
    public required double Latitude { get; init; }

    /// <summary>Longitude of the venue in degrees.</summary>
    public required double Longitude { get; init; }

    /// <summary>Name of the venue.</summary>
    public required string Title { get; init; }

    /// <summary>Address of the venue.</summary>
    public required string Address { get; init; }

    /// <summary>Foursquare identifier of the venue.</summary>
    public string? FoursquareId { get; init; }

    /// <summary>Foursquare type of the venue.</summary>
    public string? FoursquareType { get; init; }

    /// <summary>Google Places identifier of the venue.</summary>
    public string? GooglePlaceId { get; init; }

    /// <summary>Google Places type of the venue.</summary>
    public string? GooglePlaceType { get; init; }
}

/// <summary>Describes contact message content for an inline result.</summary>
public sealed class InputContactMessageContent : InputMessageContent
{
    /// <summary>Phone number of the contact.</summary>
    public required string PhoneNumber { get; init; }

    /// <summary>First name of the contact.</summary>
    public required string FirstName { get; init; }

    /// <summary>Last name of the contact.</summary>
    public string? LastName { get; init; }

    /// <summary>Additional contact data as a vCard, containing 0-2048 bytes.</summary>
    public string? VCard { get; init; }
}

/// <summary>Describes invoice message content for an inline result.</summary>
public sealed class InputInvoiceMessageContent : InputMessageContent
{
    /// <summary>Product name.</summary>
    public required string Title { get; init; }

    /// <summary>Product description.</summary>
    public required string Description { get; init; }

    /// <summary>Bot-defined invoice payload.</summary>
    public required string Payload { get; init; }

    /// <summary>Payment provider token, if applicable.</summary>
    public string? ProviderToken { get; init; }

    /// <summary>Three-letter ISO 4217 currency code.</summary>
    public required string Currency { get; init; }

    /// <summary>Price breakdown.</summary>
    public required IReadOnlyList<LabeledPrice> Prices { get; init; }

    /// <summary>Maximum accepted tip in the smallest currency units. Defaults to 0 and is unsupported for Telegram Stars.</summary>
    public int? MaxTipAmount { get; init; }

    /// <summary>Up to four positive, strictly increasing suggested tip amounts that do not exceed <see cref="MaxTipAmount"/>.</summary>
    public IReadOnlyList<int>? SuggestedTipAmounts { get; init; }

    /// <summary>JSON-serialized invoice data shared with the payment provider.</summary>
    public string? ProviderData { get; init; }

    /// <summary>URL of the product photo or service marketing image.</summary>
    public string? PhotoUrl { get; init; }

    /// <summary>Product photo size in bytes.</summary>
    public int? PhotoSize { get; init; }

    /// <summary>Product photo width.</summary>
    public int? PhotoWidth { get; init; }

    /// <summary>Product photo height.</summary>
    public int? PhotoHeight { get; init; }

    /// <summary>Whether the user's full name is required to complete the order; ignored for Telegram Stars.</summary>
    public bool? NeedName { get; init; }

    /// <summary>Whether the user's phone number is required to complete the order; ignored for Telegram Stars.</summary>
    public bool? NeedPhoneNumber { get; init; }

    /// <summary>Whether the user's email address is required to complete the order; ignored for Telegram Stars.</summary>
    public bool? NeedEmail { get; init; }

    /// <summary>Whether the user's shipping address is required to complete the order; ignored for Telegram Stars.</summary>
    public bool? NeedShippingAddress { get; init; }

    /// <summary>Whether to send the user's phone number to the payment provider; ignored for Telegram Stars.</summary>
    public bool? SendPhoneNumberToProvider { get; init; }

    /// <summary>Whether to send the user's email address to the payment provider; ignored for Telegram Stars.</summary>
    public bool? SendEmailToProvider { get; init; }

    /// <summary>Whether the final price depends on the shipping method; ignored for Telegram Stars.</summary>
    public bool? IsFlexible { get; init; }
}
