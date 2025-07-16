using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class AnswerShippingQueryParameters : ApiRequestParameters
{
    public string ShippingQueryId { get; set; }

    public bool Ok { get; set; }

    public ShippingOption[] ShippingOptions { get; set; }

    public string ErrorMessage { get; set; }
}
