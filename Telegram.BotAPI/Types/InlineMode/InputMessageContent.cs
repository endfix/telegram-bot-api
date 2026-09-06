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

    public float? HorizontalAccuracy { get; init; }

    public int? LivePeriod { get; init; }

    public int? Heading { get; init; }

    public int? ProximityAlertRadius { get; init; }
}

/// <summary>Describes venue message content for an inline result.</summary>
public sealed class InputVenueMessageContent : InputMessageContent
{
    public required double Latitude { get; init; }

    public required double Longitude { get; init; }

    public required string Title { get; init; }

    public required string Address { get; init; }

    public string? FoursquareId { get; init; }

    public string? FoursquareType { get; init; }

    public string? GooglePlaceId { get; init; }

    public string? GooglePlaceType { get; init; }
}

/// <summary>Describes contact message content for an inline result.</summary>
public sealed class InputContactMessageContent : InputMessageContent
{
    public required string PhoneNumber { get; init; }

    public required string FirstName { get; init; }

    public string? LastName { get; init; }

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

    public int? MaxTipAmount { get; init; }

    public IReadOnlyList<int>? SuggestedTipAmounts { get; init; }

    public string? ProviderData { get; init; }

    public string? PhotoUrl { get; init; }

    public int? PhotoSize { get; init; }

    public int? PhotoWidth { get; init; }

    public int? PhotoHeight { get; init; }

    public bool? NeedName { get; init; }

    public bool? NeedPhoneNumber { get; init; }

    public bool? NeedEmail { get; init; }

    public bool? NeedShippingAddress { get; init; }

    public bool? SendPhoneNumberToProvider { get; init; }

    public bool? SendEmailToProvider { get; init; }

    public bool? IsFlexible { get; init; }
}
