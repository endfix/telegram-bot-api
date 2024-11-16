namespace Telegram.BotAPI.Types.Payments;

/// <summary>
/// This object contains basic information about a successful payment.
/// </summary>
public sealed class SuccessfulPayment
{
    /// <summary>
    /// Three-letter ISO 4217 <see href="https://core.telegram.org/bots/payments#supported-currencies">currency</see> code, 
    /// or “XTR” for payments in <see href="https://t.me/BotNews/90">Telegram Stars</see>
    /// </summary>
    public string Currency { get; set; }

    /// <summary>
    /// Total price in the smallest units of the currency (integer, not float/double). For example, for a price of US$ 1.45 pass amount = 145. 
    /// See the exp parameter in <see href="https://core.telegram.org/bots/payments/currencies.json">currencies.json</see>, 
    /// it shows the number of digits past the decimal point for each currency (2 for the majority of currencies).
    /// </summary>
    public int TotalAmount { get; set; }

    /// <summary>
    /// Bot-specified invoice payload
    /// </summary>
    public string InvoicePayload { get; set; }

    /// <summary>
    /// Optional. Identifier of the shipping option chosen by the user
    /// </summary>
    public string ShippingOptionId { get; set; }

    /// <summary>
    /// Optional. Order information provided by the user
    /// </summary>
    public OrderInfo OrderInfo { get; set; }

    /// <summary>
    /// Telegram payment identifier
    /// </summary>
    public string TelegramPaymentChargeId { get; set; }

    /// <summary>
    /// Provider payment identifier
    /// </summary>
    public string ProviderPaymentChargeId { get; set; }
}
