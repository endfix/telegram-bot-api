using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

public abstract class InputMessageContent
{
    //
}

public sealed class InputTextMessageContent : InputMessageContent
{
    public required string MessageText { get; init; }

    public string? ParseMode { get; init; }

    public IReadOnlyList<MessageEntity>? Entities { get; init; }

    public LinkPreviewOptions? LinkPreviewOptions { get; init; }
}

public sealed class InputRichMessageContent : InputMessageContent
{
    public required InputRichMessage RichMessage { get; init; }
}

public sealed class InputLocationMessageContent : InputMessageContent
{
    public required double Latitude { get; init; }

    public required double Longitude { get; init; }

    public float? HorizontalAccuracy { get; init; }

    public int? LivePeriod { get; init; }

    public int? Heading { get; init; }

    public int? ProximityAlertRadius { get; init; }
}

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

public sealed class InputContactMessageContent : InputMessageContent
{
    public required string PhoneNumber { get; init; }

    public required string FirstName { get; init; }

    public string? LastName { get; init; }

    public string? VCard { get; init; }
}

public sealed class InputInvoiceMessageContent : InputMessageContent
{
    public required string Title { get; init; }

    public required string Description { get; init; }

    public required string Payload { get; init; }

    public string? ProviderToken { get; init; }

    public required string Currency { get; init; }

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
