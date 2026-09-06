using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Endfix.Telegram.BotAPI.Parameters;
using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Extensions;

public static partial class BotApiClientExtensions
{
    public static async Task<Message> SendInvoiceAsync(
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

    public static async Task<string> CreateInvoiceLinkAsync(
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

    /// <summary>Responds to a shipping query for an invoice with a flexible price.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">Shipping query result and available delivery options.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
    public static async Task<bool> AnswerShippingQueryAsync(
        this IBotApiClient client, 
        AnswerShippingQueryParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("answerShippingQuery", parameters), cancellationToken);

    /// <summary>Responds to a shipping query for an invoice with a flexible price.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="shippingQueryId">Unique identifier of the shipping query.</param>
    /// <param name="ok">Whether delivery to the specified address is possible.</param>
    /// <param name="shippingOptions">Available shipping options. Required when <paramref name="ok"/> is <see langword="true"/>.</param>
    /// <param name="errorMessage">Human-readable reason for failure. Required when <paramref name="ok"/> is <see langword="false"/>.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
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

    /// <summary>Responds to a pre-checkout query after the user confirms payment and shipping details.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">Pre-checkout result and optional failure message.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
    public static async Task<bool> AnswerPreCheckoutQueryAsync(
        this IBotApiClient client, 
        AnswerPreCheckoutQueryParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("answerPreCheckoutQuery", parameters), cancellationToken);

    /// <summary>Responds to a pre-checkout query after the user confirms payment and shipping details.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="preCheckoutQueryId">Unique identifier of the pre-checkout query.</param>
    /// <param name="ok">Whether the order can proceed.</param>
    /// <param name="errorMessage">Human-readable reason for failure. Required when <paramref name="ok"/> is <see langword="false"/>.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
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

    /// <summary>Gets the bot's current Telegram Stars balance.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">The request has no parameters in the current Bot API version.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns>The bot's current Telegram Stars balance.</returns>
    public static async Task<StarAmount> GetMyStarBalanceAsync(
        this IBotApiClient client, 
        GetMyStarBalanceParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<StarAmount>(new ApiRequest("getMyStarBalance", parameters), cancellationToken);

    /// <summary>Gets the bot's current Telegram Stars balance.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns>The bot's current Telegram Stars balance.</returns>
    public static async Task<StarAmount> GetMyStarBalanceAsync(
        this IBotApiClient client, 
        CancellationToken cancellationToken = default)
        => await client.GetMyStarBalanceAsync(new GetMyStarBalanceParameters
        {
            // No parameters required for this method
        }, cancellationToken);

    /// <summary>Gets the bot's Telegram Stars transactions in chronological order.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">Pagination options.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns>The bot's Telegram Stars transactions.</returns>
    public static async Task<StarTransactions> GetStarTransactionsAsync(
        this IBotApiClient client, 
        GetStarTransactionsParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<StarTransactions>(new ApiRequest("getStarTransactions", parameters), cancellationToken);

    /// <summary>Gets the bot's Telegram Stars transactions in chronological order.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="offset">Number of transactions to skip.</param>
    /// <param name="limit">Maximum number of transactions to retrieve, from 1 to 100. The default is 100.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns>The bot's Telegram Stars transactions.</returns>
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

    /// <summary>Refunds a successful payment made with Telegram Stars.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">User and Telegram payment identifiers.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
    public static async Task<bool> RefundStarPaymentAsync(
        this IBotApiClient client, 
        RefundStarPaymentParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("refundStarPayment", parameters), cancellationToken);

    /// <summary>Refunds a successful payment made with Telegram Stars.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="userId">Identifier of the user whose payment is refunded.</param>
    /// <param name="telegramPaymentChargeId">Telegram payment identifier.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
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

    /// <summary>Changes whether a Telegram Stars subscription will be extended.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="parameters">User, payment and cancellation state.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
    public static async Task<bool> EditUserStarSubscriptionAsync(
        this IBotApiClient client, 
        EditUserStarSubscriptionParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("editUserStarSubscription", parameters), cancellationToken);

    /// <summary>Changes whether a Telegram Stars subscription will be extended.</summary>
    /// <param name="client">Bot API client used to send the request.</param>
    /// <param name="userId">Identifier of the user whose subscription is edited.</param>
    /// <param name="telegramPaymentChargeId">Telegram payment identifier for the subscription.</param>
    /// <param name="isCanceled">Whether to cancel extension. Set to <see langword="false"/> to re-enable a subscription previously canceled by the bot.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns><see langword="true"/> on success.</returns>
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
