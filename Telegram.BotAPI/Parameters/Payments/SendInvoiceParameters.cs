using System.Collections.Generic;
using Telegram.BotAPI.Protocol;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class SendInvoiceParameters : ApiRequestParameters
{
    public required ChatIdSource ChatId { get; init; }

    public long? MessageThreadId { get; init; }

    public long? DirectMessagesTopicId { get; init; }

    public required string Title { get; init; }

    public required string Description { get; init; }

    public required string Payload { get; init; }

    public string? ProviderToken { get; init; }

    public required string Currency { get; init; }

    public required IReadOnlyList<LabeledPrice> Prices { get; init; }

    public int? MaxTipAmount { get; init; }

    public IReadOnlyList<int>? SuggestedTipAmounts { get; init; }

    public string? StartParameter { get; init; }

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

    public bool? DisableNotification { get; init; }

    public bool? ProtectContent { get; init; }

    public bool? AllowPaidBroadcast { get; init; }

    public string? MessageEffectId { get; init; }

    public SuggestedPostParameters? SuggestedPostParameters { get; init; }

    public ReplyParameters? ReplyParameters { get; init; }

    public InlineKeyboardMarkup? ReplyMarkup { get; init; }
}
