using System.Collections.Generic;
using Telegram.BotAPI.Types.Payments;

namespace Telegram.BotAPI.Types.InlineMode;

public abstract class InputMessageContent
{
    //
}

public sealed class InputTextMessageContent : InputMessageContent
{
    public string MessageText { get; set; }

    public string ParseMode { get; set; }

    public List<MessageEntity> Entities { get; set; }

    public LinkPreviewOptions LinkPreviewOptions { get; set; }
}

public sealed class InputLocationMessageContent : InputMessageContent
{
    public float Latitude { get; set; }

    public float Longitude { get; set; }

    public float HorizontalAccuracy { get; set; }

    public int LivePeriod { get; set; }

    public int Heading { get; set; }

    public int ProximityAlertRadius { get; set; }
}

public sealed class InputVenueMessageContent : InputMessageContent
{
    public float Latitude { get; set; }

    public float Longitude { get; set; }

    public string Title { get; set; }

    public string Address { get; set; }

    public string FoursquareId { get; set; }

    public string FoursquareType { get; set; }

    public string GooglePlaceId { get; set; }

    public string GooglePlaceType { get; set; }
}

public sealed class InputContactMessageContent : InputMessageContent
{
    public string PhoneNumber { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Vcard { get; set; }
}

public sealed class InputInvoiceMessageContent : InputMessageContent
{
    public string Title { get; set; }

    public string Description { get; set; }

    public string Payload { get; set; }

    public string ProviderToken { get; set; }

    public string Currency { get; set; }

    public List<LabeledPrice> Prices { get; set; }

    public int MaxTipAmount { get; set; }

    public List<int> SuggestedTipAmounts { get; set; }

    public string ProviderData { get; set; }

    public string PhotoUrl { get; set; }

    public int PhotoSize { get; set; }

    public int PhotoWidth { get; set; }

    public int PhotoHeight { get; set; }

    public bool NeedName { get; set; }

    public bool NeedPhoneNumber { get; set; }

    public bool NeedEmail { get; set; }

    public bool NeedShippingAddress { get; set; }

    public bool SendPhoneNumberToProvider { get; set; }

    public bool SendEmailToProvider { get; set; }

    public bool IsFlexible { get; set; }
}
