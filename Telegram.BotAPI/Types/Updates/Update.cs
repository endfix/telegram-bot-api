using System;
using Telegram.BotAPI.Extensions;
using Telegram.BotAPI.Types.InlineMode;
using Telegram.BotAPI.Types.Payments;

namespace Telegram.BotAPI.Types.Updates;

// https://core.telegram.org/bots/api#update
public sealed class Update
{
    public long UpdateId { get; set; }

    public Message Message { get; set; }

    public Message EditedMessage { get; set; }

    public Message ChannelPost { get; set; }

    public Message EditedChannelPost { get; set; }

    public BusinessConnection BusinessConnection { get; set; }

    public Message BusinessMessage { get; set; }

    public Message EditedBusinessMessage { get; set; }

    public BusinessMessagesDeleted DeletedBusinessMessages { get; set; }

    public MessageReactionUpdated MessageReaction { get; set; }

    public MessageReactionCountUpdated MessageReactionCount { get; set; }

    public InlineQuery InlineQuery { get; set; }

    public ChosenInlineResult ChosenInlineResult { get; set; }

    public CallbackQuery CallbackQuery { get; set; }

    public ShippingQuery ShippingQuery { get; set; }

    public PreCheckoutQuery PreCheckoutQuery { get; set; }

    public PaidMediaPurchased PurchasedPaidMedia { get; set; }

    public Poll Poll { get; set; }

    public PollAnswer PollAnswer { get; set; }

    public ChatMemberUpdated MyChatMember { get; set; }

    public ChatMemberUpdated ChatMember { get; set; }

    public ChatJoinRequest ChatJoinRequest { get; set; }

    public ChatBoostUpdated ChatBoost { get; set; }

    public ChatBoostRemoved RemovedChatBoost { get; set; }

    public bool IsMessage() { return Message is not null; }

    public bool IsEditedMessage() { return EditedMessage is not null; }

    public bool IsChannelPost() { return ChannelPost is not null; }

    public bool IsEditedChannelPost() { return EditedChannelPost is not null; }

    public bool IsBusinessConnection() { return BusinessConnection is not null; }

    public bool IsBusinessMessage() { return BusinessMessage is not null; }

    public bool IsEditedBusinessMessage() { return EditedBusinessMessage is not null; }

    public bool IsDeletedBusinessMessages() { return DeletedBusinessMessages is not null; }

    public bool IsMessageReaction() { return MessageReaction is not null; }

    public bool IsMessageReactionCount() { return MessageReactionCount is not null; }

    public bool IsInlineQuery() { return InlineQuery is not null; }

    public bool IsChosenInlineResult() { return ChosenInlineResult is not null; }

    public bool IsCallbackQuery() { return CallbackQuery is not null; }

    public bool IsShippingQuery() { return ShippingQuery is not null; }

    public bool IsPreCheckoutQuery() { return PreCheckoutQuery is not null; }

    public bool IsPurchasedPaidMedia() { return PurchasedPaidMedia is not null; }

    public bool IsPoll() { return Poll is not null; }

    public bool IsPollAnswer() { return PollAnswer is not null; }

    public bool IsMyChatMember() { return MyChatMember is not null; }

    public bool IsChatMember() { return ChatMember is not null; }

    public bool IsChatJoinRequest() { return ChatJoinRequest is not null; }

    public bool IsChatBoost() { return ChatBoost is not null; }

    public bool IsRemovedChatBoost() { return RemovedChatBoost is not null; }

    public string GetUpdateType()
    {
        if (IsMessage()) { return UpdateTypes.MESSAGE; }

        if (IsEditedMessage()) { return UpdateTypes.EDITED_MESSAGE; }

        if (IsChannelPost()) { return UpdateTypes.CHANNEL_POST; }

        if (IsEditedChannelPost()) { return UpdateTypes.EDITED_CHANNEL_POST; }

        if (IsBusinessConnection()) { return UpdateTypes.BUSINESS_CONNECTiON; }

        if (IsBusinessMessage()) { return UpdateTypes.BUSINESS_MESSAGE; }

        if (IsEditedBusinessMessage()) { return UpdateTypes.EDITED_BUSINESS_MESSAGE; }

        if (IsDeletedBusinessMessages()) { return UpdateTypes.DELETED_BUSINESS_MESSAGES; }

        if (IsMessageReaction()) { return UpdateTypes.MESSAGE_REACTION; }

        if (IsMessageReactionCount()) { return UpdateTypes.MESSAGE_REACTION_COUNT; }

        if (IsInlineQuery()) { return UpdateTypes.INLINE_QUERY; }

        if (IsChosenInlineResult()) { return UpdateTypes.CHOSEN_INLINE_RESULT; }

        if (IsCallbackQuery()) { return UpdateTypes.CALLBACK_QUERY; }

        if (IsShippingQuery()) { return UpdateTypes.SHIPPING_QUERY; }

        if (IsPreCheckoutQuery()) { return UpdateTypes.PRE_CHECKOUT_QUERY; }

        if (IsPurchasedPaidMedia()) { return UpdateTypes.PURCHASED_PAID_MEDIA; }

        if (IsPoll()) { return UpdateTypes.POLL; }

        if (IsPollAnswer()) { return UpdateTypes.POLL_ANSWER; }

        if (IsMyChatMember()) { return UpdateTypes.MY_CHAT_MEMBER; }

        if (IsChatMember()) { return UpdateTypes.CHAT_MEMBER; }

        if (IsChatJoinRequest()) { return UpdateTypes.CHAT_JOIN_REQUEST; }

        if (IsChatBoost()) { return UpdateTypes.CHAT_BOOST; }

        if (IsRemovedChatBoost()) { return UpdateTypes.REMOVED_CHAT_BOOST; }

        throw new NotSupportedException($"json: {this.Serialize()}");
    }
}

public static class UpdateTypes
{
    public const string MESSAGE = "message";

    public const string EDITED_MESSAGE = "edited_message";

    public const string CHANNEL_POST = "channel_post";

    public const string EDITED_CHANNEL_POST = "edited_channel_post";

    public const string BUSINESS_CONNECTiON = "business_connection";

    public const string BUSINESS_MESSAGE = "business_message";

    public const string EDITED_BUSINESS_MESSAGE = "edited_business_message";

    public const string DELETED_BUSINESS_MESSAGES = "deleted_business_messages";

    public const string MESSAGE_REACTION = "message_reaction";

    public const string MESSAGE_REACTION_COUNT = "message_reaction_count";

    public const string INLINE_QUERY = "inline_query";

    public const string CHOSEN_INLINE_RESULT = "chosen_inline_result";

    public const string CALLBACK_QUERY = "callback_query";

    public const string SHIPPING_QUERY = "shipping_query";

    public const string PRE_CHECKOUT_QUERY = "pre_checkout_query";

    public const string PURCHASED_PAID_MEDIA = "purchased_paid_media";

    public const string POLL = "poll";

    public const string POLL_ANSWER = "poll_answer";

    public const string MY_CHAT_MEMBER = "my_chat_member";

    public const string CHAT_MEMBER = "chat_member";

    public const string CHAT_JOIN_REQUEST = "chat_join_request";

    public const string CHAT_BOOST = "chat_boost";

    public const string REMOVED_CHAT_BOOST = "removed_chat_boost";
}
