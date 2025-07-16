using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class CreateInvoiceLinkParameters : ApiRequestParameters
{
    public string BusinessConnectionId { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public string Payload { get; set; }

    public string ProviderToken { get; set; }

    public string Currency { get; set; }

    public LabeledPrice[] Prices { get; set; }

    public int SubscriptionPeriod { get; set; }

    public int MaxTipAmount { get; set; }

    public int[] SuggestedTipAmounts { get; set; }

    public string ProviderData { get; set; }

    public string PhotoUrl { get; set; }

    public string PhotoSize { get; set; }

    public string PhotoWidth { get; set; }

    public string PhotoHeight { get; set; }

    public bool NeedName { get; set; }

    public bool NeedPhoneNumber { get; set; }

    public bool NeedEmail { get; set; }

    public bool NeedShippingAddress { get; set; }

    public bool SendPhoneNumberToProvider { get; set; }

    public bool SendEmailToProvider { get; set; }

    public bool IsFlexible { get; set; }
}
