using System.Threading.Tasks;
using Telegram.BotAPI.Types.Payments;
using Telegram.BotAPI.Types;
using Telegram.BotAPI.MethodArgs;

namespace Telegram.BotAPI.Extensions;

public static partial class BotClientExtensions
{
    public static async Task<ResponseAPI<Message>> SendInvoiceAsync(this TelegramBotAPIClient api, SendInvoiceArgs args = null)
    {
        return await api.RequestAsync<Message>("sendInvoice", args);
    }

    public static async Task<ResponseAPI<string>> CreateInvoiceLinkAsync(this TelegramBotAPIClient api, CreateInvoiceLinkArgs args = null)
    {
        return await api.RequestAsync<string>("createInvoiceLink", args);
    }

    public static async Task<ResponseAPI<bool>> AnswerShippingQueryAsync(this TelegramBotAPIClient api, AnswerShippingQueryArgs args = null)
    {
        return await api.RequestAsync<bool>("answerShippingQuery", args);
    }

    public static async Task<ResponseAPI<bool>> AnswerPreCheckoutQueryAsync(this TelegramBotAPIClient api, AnswerPreCheckoutQueryArgs args = null)
    {
        return await api.RequestAsync<bool>("answerPreCheckoutQuery", args);
    }

    public static async Task<ResponseAPI<StarTransactions>> GetStarTransactionsAsync(this TelegramBotAPIClient api, GetStarTransactionsArgs args = null)
    {
        return await api.RequestAsync<StarTransactions>("getStarTransactions", args);
    }

    public static async Task<ResponseAPI<bool>> RefundStarPaymentAsync(this TelegramBotAPIClient api, RefundStarPaymentArgs args = null)
    {
        return await api.RequestAsync<bool>("refundStarPayment", args);
    }
}
