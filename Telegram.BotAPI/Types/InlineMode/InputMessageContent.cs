using System.Collections.Generic;
using Telegram.BotAPI.Types.AvailableTypes;
using Telegram.BotAPI.Types.Payments;

namespace Telegram.BotAPI.Types.InlineMode;

/// <summary>
/// This object represents the content of a message to be sent as a result of an inline query. Telegram clients currently support the following 5 types:
/// <see cref="InputTextMessageContent">InputTextMessageContent</see> or 
/// <see cref="InputLocationMessageContent">InputLocationMessageContent</see> or 
/// <see cref="InputVenueMessageContent">InputVenueMessageContent</see> or 
/// <see cref="InputContactMessageContent">InputContactMessageContent</see> or 
/// <see cref="InputInvoiceMessageContent">InputInvoiceMessageContent</see>
/// </summary>
public abstract class InputMessageContent
{
    //
}

/// <summary>
/// Represents the <see cref="InputMessageContent">content</see> of a text message to be sent as the result of an inline query.
/// </summary>
public sealed class InputTextMessageContent : InputMessageContent
{
    /// <summary>
    /// Text of the message to be sent, 1-4096 characters
    /// </summary>
    public string MessageText { get; set; }

    /// <summary>
    /// Optional. Mode for parsing entities in the message text. See <see cref="https://core.telegram.org/bots/api#formatting-options">formatting options</see> for more details.
    /// </summary>
    public string ParseMode { get; set; }

    /// <summary>
    /// Optional. List of special entities that appear in message text, which can be specified instead of parse_mode
    /// </summary>
    public List<MessageEntity> Entities { get; set; }

    /// <summary>
    /// Optional. Link preview generation options for the message
    /// </summary>
    public LinkPreviewOptions LinkPreviewOptions { get; set; }
}

/// <summary>
/// Represents the <see cref="InputMessageContent">content</see> of a location message to be sent as the result of an inline query.
/// </summary>
public sealed class InputLocationMessageContent : InputMessageContent
{
    /// <summary>
    /// Latitude of the location in degrees
    /// </summary>
    public float Latitude { get; set; }

    /// <summary>
    /// Longitude of the location in degrees
    /// </summary>
    public float Longitude { get; set; }

    /// <summary>
    /// Optional. The radius of uncertainty for the location, measured in meters; 0-1500
    /// </summary>
    public float HorizontalAccuracy { get; set; }

    /// <summary>
    /// Optional. Period in seconds during which the location can be updated, should be between 60 and 86400, or 0x7FFFFFFF for live locations that can be edited indefinitely.
    /// </summary>
    public int LivePeriod { get; set; }

    /// <summary>
    /// Optional. For live locations, a direction in which the user is moving, in degrees. Must be between 1 and 360 if specified.
    /// </summary>
    public int Heading { get; set; }

    /// <summary>
    /// Optional. For live locations, a maximum distance for proximity alerts about approaching another chat member, in meters. Must be between 1 and 100000 if specified.
    /// </summary>
    public int ProximityAlertRadius { get; set; }
}

/// <summary>
/// Represents the <see cref="InputMessageContent">content</see> of a venue message to be sent as the result of an inline query.
/// </summary>
public sealed class InputVenueMessageContent : InputMessageContent
{
    /// <summary>
    /// Latitude of the venue in degrees
    /// </summary>
    public float Latitude { get; set; }

    /// <summary>
    /// Longitude of the venue in degrees
    /// </summary>
    public float Longitude { get; set; }

    /// <summary>
    /// Name of the venue
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Address of the venue
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    /// Optional. Foursquare identifier of the venue, if known
    /// </summary>
    public string FoursquareId { get; set; }

    /// <summary>
    /// Optional. Foursquare type of the venue, if known. (For example, “arts_entertainment/default”, “arts_entertainment/aquarium” or “food/icecream”.)
    /// </summary>
    public string FoursquareType { get; set; }

    /// <summary>
    /// Optional. Google Places identifier of the venue
    /// </summary>
    public string GooglePlaceId { get; set; }

    /// <summary>
    /// Optional. Google Places type of the venue. (See <see href="https://developers.google.com/places/web-service/supported_types">supported types</see>.)
    /// </summary>
    public string GooglePlaceType { get; set; }
}

/// <summary>
/// Represents the <see cref="InputMessageContent">content</see> of a contact message to be sent as the result of an inline query.
/// </summary>
public sealed class InputContactMessageContent : InputMessageContent
{
    /// <summary>
    /// Contact's phone number
    /// </summary>
    public string PhoneNumber { get; set; }

    /// <summary>
    /// Contact's first name
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Optional. Contact's last name
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Optional. Additional data about the contact in the form of a <see href="https://en.wikipedia.org/wiki/VCard">vCard</see>, 0-2048 bytes
    /// </summary>
    public string VCard { get; set; }
}

/// <summary>
/// Represents the <see cref="InputMessageContent">content</see> of an invoice message to be sent as the result of an inline query.
/// </summary>
public sealed class InputInvoiceMessageContent : InputMessageContent
{
    /// <summary>
    /// Product name, 1-32 characters
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Product description, 1-255 characters
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Bot-defined invoice payload, 1-128 bytes. This will not be displayed to the user, use it for your internal processes.
    /// </summary>
    public string Payload { get; set; }

    /// <summary>
    /// Optional. Payment provider token, obtained via <see href="https://t.me/botfather">@BotFather</see>. 
    /// Pass an empty string for payments in <see href="https://t.me/BotNews/90">Telegram Stars</see>.
    /// </summary>
    public string ProviderToken { get; set; }

    /// <summary>
    /// Three-letter ISO 4217 currency code, see <see href="https://core.telegram.org/bots/payments#supported-currencies">more on currencies</see>. 
    /// Pass “XTR” for payments in <see href="https://t.me/BotNews/90">Telegram Stars</see>.
    /// </summary>
    public string Currency { get; set; }

    /// <summary>
    /// Price breakdown, a JSON-serialized list of components (e.g. product price, tax, discount, delivery cost, delivery tax, bonus, etc.). 
    /// Must contain exactly one item for payments in <see href="https://t.me/BotNews/90">Telegram Stars</see>.
    /// </summary>
    public List<LabeledPrice> Prices { get; set; }

    /// <summary>
    /// Optional. The maximum accepted amount for tips in the smallest units of the currency (integer, not float/double). 
    /// For example, for a maximum tip of US$ 1.45 pass max_tip_amount = 145. See the exp parameter in <see href="https://core.telegram.org/bots/payments/currencies.json">currencies.json</see>, 
    /// it shows the number of digits past the decimal point for each currency (2 for the majority of currencies). 
    /// Defaults to 0. Not supported for payments in <see href="https://t.me/BotNews/90">Telegram Stars</see>.
    /// </summary>
    public int MaxTipAmount { get; set; }

    /// <summary>
    /// Optional. A JSON-serialized array of suggested amounts of tip in the smallest units of the currency (integer, not float/double). At most 4 suggested tip amounts can be specified. 
    /// The suggested tip amounts must be positive, passed in a strictly increased order and must not exceed max_tip_amount.
    /// </summary>
    public List<int> SuggestedTipAmounts { get; set; }

    /// <summary>
    /// Optional. A JSON-serialized object for data about the invoice, which will be shared with the payment provider. 
    /// A detailed description of the required fields should be provided by the payment provider.
    /// </summary>
    public string ProviderData { get; set; }

    /// <summary>
    /// Optional. URL of the product photo for the invoice. Can be a photo of the goods or a marketing image for a service.
    /// </summary>
    public string PhotoUrl { get; set; }

    /// <summary>
    /// Optional. Photo size in bytes
    /// </summary>
    public int PhotoSize { get; set; }

    /// <summary>
    /// Optional. Photo width
    /// </summary>
    public int PhotoWidth { get; set; }

    /// <summary>
    /// Optional. Photo height
    /// </summary>
    public int PhotoHeight { get; set; }

    /// <summary>
    /// Optional. Pass True if you require the user's full name to complete the order. 
    /// Ignored for payments in <see href="https://t.me/BotNews/90">Telegram Stars</see>.
    /// </summary>
    public bool NeedName { get; set; }

    /// <summary>
    /// Optional. Pass True if you require the user's phone number to complete the order. 
    /// Ignored for payments in <see href="https://t.me/BotNews/90">Telegram Stars</see>.
    /// </summary>
    public bool NeedPhoneNumber { get; set; }

    /// <summary>
    /// Optional. Pass True if you require the user's email address to complete the order. 
    /// Ignored for payments in <see href="https://t.me/BotNews/90">Telegram Stars</see>.
    /// </summary>
    public bool NeedEmail { get; set; }

    /// <summary>
    /// Optional. Pass True if you require the user's shipping address to complete the order. 
    /// Ignored for payments in <see href="https://t.me/BotNews/90">Telegram Stars</see>.
    /// </summary>
    public bool NeedShippingAddress { get; set; }

    /// <summary>
    /// Optional. Pass True if the user's phone number should be sent to the provider. 
    /// Ignored for payments in <see href="https://t.me/BotNews/90">Telegram Stars</see>.
    /// </summary>
    public bool SendPhoneNumberToProvider { get; set; }

    /// <summary>
    /// Optional. Pass True if the user's email address should be sent to the provider. 
    /// Ignored for payments in <see href="https://t.me/BotNews/90">Telegram Stars</see>.
    /// </summary>
    public bool SendEmailToProvider { get; set; }

    /// <summary>
    /// Optional. Pass True if the final price depends on the shipping method. 
    /// Ignored for payments in <see href="https://t.me/BotNews/90">Telegram Stars</see>.
    /// </summary>
    public bool IsFlexible { get; set; }
}
