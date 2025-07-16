using System.Threading.Tasks;
using Telegram.BotAPI.Parameters;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI;

public partial class BotApiClient
{
    public async Task<ApiResponse<Message>> SendInvoiceAsync(SendInvoiceParameters parameters)
    {
        return await RequestAsync<Message>(new ApiRequest("sendInvoice", parameters));
    }

    public async Task<ApiResponse<string>> CreateInvoiceLinkAsync(CreateInvoiceLinkParameters parameters)
    {
        return await RequestAsync<string>(new ApiRequest("createInvoiceLink", parameters));
    }

    public async Task<ApiResponse<bool>> AnswerShippingQueryAsync(AnswerShippingQueryParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("answerShippingQuery", parameters));
    }

    public async Task<ApiResponse<bool>> AnswerPreCheckoutQueryAsync(AnswerPreCheckoutQueryParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("answerPreCheckoutQuery", parameters));
    }

    public async Task<ApiResponse<StarTransactions>> GetStarTransactionsAsync(GetStarTransactionsyParameters parameters)
    {
        return await RequestAsync<StarTransactions>(new ApiRequest("getStarTransactions", parameters));
    }

    public async Task<ApiResponse<bool>> RefundStarPaymentAsync(RefundStarPaymentParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("refundStarPayment", parameters));
    }

    public async Task<ApiResponse<bool>> EditUserStarSubscriptionAsync(EditUserStarSubscriptionParameters parameters)
    {
        return await RequestAsync<bool>(new ApiRequest("editUserStarSubscription", parameters));
    }
}
