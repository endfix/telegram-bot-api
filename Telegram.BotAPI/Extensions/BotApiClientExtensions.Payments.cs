using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Endfix.Telegram.BotAPI.Parameters;
using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Extensions;

public static partial class BotApiClientExtensions
{
    internal static async Task<Message> SendInvoiceAsync(
        this IBotApiClient client, 
        SendInvoiceParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<Message>(new ApiRequest("sendInvoice", parameters), cancellationToken);

    public static async Task<Message> SendInvoiceAsync(
        this IBotApiClient client,
        ChatIdSource ChatId,
        string title,
        string description,
        string payload,
        string currency,
        IReadOnlyList<LabeledPrice> prices,
        long? messageThreadId = null,
        long? directMessagesTopicId = null,
        string? providerToken = null,
        int? maxTipAmount = null,
        IReadOnlyList<int>? suggestedTipAmounts = null,
        string? startParameter = null,
        string? providerData = null,
        string? photoUrl = null,
        int? photoSize = null,
        int? photoWidth = null,
        int? photoHeight = null,
        bool? needName = null,
        bool? needPhoneNumber = null,
        bool? needEmail = null,
        bool? needShippingAddress = null,
        bool? sendPhoneNumberToProvider = null,
        bool? sendEmailToProvider = null,
        bool? isFlexible = null,
        bool? disableNotification = null,
        bool? protectContent = null,
        bool? allowPaidBroadcast = null,
        string? messageEffectId = null,
        SuggestedPostParameters? suggestedPostParameters = null,
        ReplyParameters? replyParameters = null,
        InlineKeyboardMarkup? replyMarkup = null,
        CancellationToken cancellationToken = default)
        => await client.SendInvoiceAsync(new SendInvoiceParameters
        {
            ChatId = ChatId,
            MessageThreadId = messageThreadId,
            DirectMessagesTopicId = directMessagesTopicId,
            Title = title,
            Description = description,
            Payload = payload,
            ProviderToken = providerToken,
            Currency = currency,
            Prices = prices,
            MaxTipAmount = maxTipAmount,
            SuggestedTipAmounts = suggestedTipAmounts,
            StartParameter = startParameter,
            ProviderData = providerData,
            PhotoUrl = photoUrl,
            PhotoSize = photoSize,
            PhotoWidth = photoWidth,
            PhotoHeight = photoHeight,
            NeedName = needName,
            NeedPhoneNumber = needPhoneNumber,
            NeedEmail = needEmail,
            NeedShippingAddress = needShippingAddress,
            SendPhoneNumberToProvider = sendPhoneNumberToProvider,
            SendEmailToProvider = sendEmailToProvider,
            IsFlexible = isFlexible,
            DisableNotification = disableNotification,
            ProtectContent = protectContent,
            AllowPaidBroadcast = allowPaidBroadcast,
            MessageEffectId = messageEffectId,
            SuggestedPostParameters = suggestedPostParameters,
            ReplyParameters = replyParameters,
            ReplyMarkup = replyMarkup
        }, cancellationToken);

    internal static async Task<string> CreateInvoiceLinkAsync(
        this IBotApiClient client, 
        CreateInvoiceLinkParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<string>(new ApiRequest("createInvoiceLink", parameters), cancellationToken);

    public static async Task<string> CreateInvoiceLinkAsync(
        this IBotApiClient client,
        string title,
        string description,
        string payload,
        string currency,
        IReadOnlyList<LabeledPrice> prices,
        string? businessConnectionId = null,
        string? providerToken = null,
        int? subscriptionPeriod = null,
        int? maxTipAmount = null,
        IReadOnlyList<int>? suggestedTipAmounts = null,
        string? providerData = null,
        string? photoUrl = null,
        int? photoSize = null,
        int? photoWidth = null,
        int? photoHeight = null,
        bool? needName = null,
        bool? needPhoneNumber = null,
        bool? needEmail = null,
        bool? needShippingAddress = null,
        bool? sendPhoneNumberToProvider = null,
        bool? sendEmailToProvider = null,
        bool? isFlexible = null,
        CancellationToken cancellationToken = default)
        => await client.CreateInvoiceLinkAsync(new CreateInvoiceLinkParameters
        {
            BusinessConnectionId = businessConnectionId,
            Title = title,
            Description = description,
            Payload = payload,
            ProviderToken = providerToken,
            Currency = currency,
            Prices = prices,
            SubscriptionPeriod = subscriptionPeriod,
            MaxTipAmount = maxTipAmount,
            SuggestedTipAmounts = suggestedTipAmounts,
            ProviderData = providerData,
            PhotoUrl = photoUrl,
            PhotoSize = photoSize,
            PhotoWidth = photoWidth,
            PhotoHeight = photoHeight,
            NeedName = needName,
            NeedPhoneNumber = needPhoneNumber,
            NeedEmail = needEmail,
            NeedShippingAddress = needShippingAddress,
            SendPhoneNumberToProvider = sendPhoneNumberToProvider,
            SendEmailToProvider = sendEmailToProvider,
            IsFlexible = isFlexible
        }, cancellationToken);

    internal static async Task<bool> AnswerShippingQueryAsync(
        this IBotApiClient client, 
        AnswerShippingQueryParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("answerShippingQuery", parameters), cancellationToken);

    public static async Task<bool> AnswerShippingQueryAsync(
        this IBotApiClient client,
        string shippingQueryId,
        bool ok,
        IReadOnlyList<ShippingOption>? shippingOptions = null,
        string? errorMessage = null,
        CancellationToken cancellationToken = default)
        => await client.AnswerShippingQueryAsync(new AnswerShippingQueryParameters
        {
            ShippingQueryId = shippingQueryId,
            Ok = ok,
            ShippingOptions = shippingOptions,
            ErrorMessage = errorMessage
        }, cancellationToken);

    internal static async Task<bool> AnswerPreCheckoutQueryAsync(
        this IBotApiClient client, 
        AnswerPreCheckoutQueryParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("answerPreCheckoutQuery", parameters), cancellationToken);

    public static async Task<bool> AnswerPreCheckoutQueryAsync(
        this IBotApiClient client,
        string preCheckoutQueryId,
        bool ok,
        string? errorMessage = null,
        CancellationToken cancellationToken = default)
        => await client.AnswerPreCheckoutQueryAsync(new AnswerPreCheckoutQueryParameters
        {
            PreCheckoutQueryId = preCheckoutQueryId,
            Ok = ok,
            ErrorMessage = errorMessage
        }, cancellationToken);

    internal static async Task<StarAmount> GetMyStarBalanceAsync(
        this IBotApiClient client, 
        GetMyStarBalanceParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<StarAmount>(new ApiRequest("getMyStarBalance", parameters), cancellationToken);

    public static async Task<StarAmount> GetMyStarBalanceAsync(
        this IBotApiClient client, 
        CancellationToken cancellationToken = default)
        => await client.GetMyStarBalanceAsync(new GetMyStarBalanceParameters
        {
            // No parameters required for this method
        }, cancellationToken);

    internal static async Task<StarTransactions> GetStarTransactionsAsync(
        this IBotApiClient client, 
        GetStarTransactionsParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<StarTransactions>(new ApiRequest("getStarTransactions", parameters), cancellationToken);

    public static async Task<StarTransactions> GetStarTransactionsAsync(
        this IBotApiClient client,
        int? offset = null,
        int? limit = null,
        CancellationToken cancellationToken = default)
        => await client.GetStarTransactionsAsync(new GetStarTransactionsParameters
        {
            Offset = offset,
            Limit = limit
        }, cancellationToken);

    internal static async Task<bool> RefundStarPaymentAsync(
        this IBotApiClient client, 
        RefundStarPaymentParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("refundStarPayment", parameters), cancellationToken);

    public static async Task<bool> RefundStarPaymentAsync(
        this IBotApiClient client,
        long userId,
        string telegramPaymentChargeId,
        CancellationToken cancellationToken = default)
        => await client.RefundStarPaymentAsync(new RefundStarPaymentParameters
        {
            UserId = userId,
            TelegramPaymentChargeId = telegramPaymentChargeId
        }, cancellationToken);

    internal static async Task<bool> EditUserStarSubscriptionAsync(
        this IBotApiClient client, 
        EditUserStarSubscriptionParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("editUserStarSubscription", parameters), cancellationToken);

    public static async Task<bool> EditUserStarSubscriptionAsync(
        this IBotApiClient client,
        long userId,
        string telegramPaymentChargeId,
        bool isCanceled,
        CancellationToken cancellationToken = default)
        => await client.EditUserStarSubscriptionAsync(new EditUserStarSubscriptionParameters
        {
            UserId = userId,
            TelegramPaymentChargeId = telegramPaymentChargeId,
            IsCanceled = isCanceled
        }, cancellationToken);
}
