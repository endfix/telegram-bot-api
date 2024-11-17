using System;
using Telegram.BotAPI.Extensions;
using Telegram.BotAPI.Types.AvailableTypes;
using Telegram.BotAPI.Types.InlineMode;
using Telegram.BotAPI.Types.Payments;

namespace Telegram.BotAPI.Types.GettingUpdates;

/// <summary>
/// This object represents an incoming update.
/// At most one of the optional parameters can be present in any given update.
/// </summary>
public sealed class Update
{
    /// <summary>
    /// The update's unique identifier. Update identifiers start from a certain positive number and increase sequentially. 
    /// This identifier becomes especially handy if you're using <see href="https://core.telegram.org/bots/api#setwebhook">webhooks</see>, 
    /// since it allows you to ignore repeated updates or to restore the correct update sequence, 
    /// should they get out of order. If there are no new updates for at least a week, then identifier of the next update will be chosen randomly instead of sequentially.
    /// </summary>
    public long UpdateId { get; set; }

    /// <summary>
    /// Optional. New incoming message of any kind - text, photo, sticker, etc.
    /// </summary>
    public Message Message { get; set; }

    /// <summary>
    /// Optional. New version of a message that is known to the bot and was edited. 
    /// This update may at times be triggered by changes to message fields that are either unavailable or not actively used by your bot.
    /// </summary>
    public Message EditedMessage { get; set; }

    /// <summary>
    /// Optional. New incoming channel post of any kind - text, photo, sticker, etc.
    /// </summary>
    public Message ChannelPost { get; set; }

    /// <summary>
    /// Optional. New version of a channel post that is known to the bot and was edited. 
    /// This update may at times be triggered by changes to message fields that are either unavailable or not actively used by your bot.
    /// </summary>
    public Message EditedChannelPost { get; set; }

    /// <summary>
    /// Optional. The bot was connected to or disconnected from a business account, or a user edited an existing connection with the bot
    /// </summary>
    public BusinessConnection BusinessConnection { get; set; }

    /// <summary>
    /// Optional. New message from a connected business account
    /// </summary>
    public Message BusinessMessage { get; set; }

    /// <summary>
    /// Optional. New version of a message from a connected business account
    /// </summary>
    public Message EditedBusinessMessage { get; set; }

    /// <summary>
    /// Optional. Messages were deleted from a connected business account
    /// </summary>
    public BusinessMessagesDeleted DeletedBusinessMessages { get; set; }

    /// <summary>
    /// Optional. A reaction to a message was changed by a user. The bot must be an administrator 
    /// in the chat and must explicitly specify "message_reaction" in the list of allowed_updates to receive these updates. 
    /// The update isn't received for reactions set by bots.
    /// </summary>
    public MessageReactionUpdated MessageReaction { get; set; }

    /// <summary>
    /// Optional. Reactions to a message with anonymous reactions were changed. The bot must be an administrator 
    /// in the chat and must explicitly specify "message_reaction_count" in the list of allowed_updates to receive these updates. 
    /// The updates are grouped and can be sent with delay up to a few minutes.
    /// </summary>
    public MessageReactionCountUpdated MessageReactionCount { get; set; }

    /// <summary>
    /// Optional. New incoming <see href="https://core.telegram.org/bots/api#inline-mode">inline</see> query
    /// </summary>
    public InlineQuery InlineQuery { get; set; }

    /// <summary>
    /// Optional. The result of an <see href="https://core.telegram.org/bots/api#inline-mode">inline</see> query that was chosen by a user and sent to their chat partner. 
    /// Please see our documentation on the <see href="https://core.telegram.org/bots/inline#collecting-feedback">feedback collecting</see> for details on how to enable these updates for your bot.
    /// </summary>
    public ChosenInlineResult ChosenInlineResult { get; set; }

    /// <summary>
    /// Optional. New incoming callback query
    /// </summary>
    public CallbackQuery CallbackQuery { get; set; }

    /// <summary>
    /// Optional. New incoming shipping query. Only for invoices with flexible price
    /// </summary>
    public ShippingQuery ShippingQuery { get; set; }

    /// <summary>
    /// Optional. New incoming pre-checkout query. Contains full information about checkout
    /// </summary>
    public PreCheckoutQuery PreCheckoutQuery { get; set; }

    /// <summary>
    /// Optional. A user purchased paid media with a non-empty payload sent by the bot in a non-channel chat
    /// </summary>
    public PaidMediaPurchased PurchasedPaidMedia { get; set; }

    /// <summary>
    /// Optional. New poll state. Bots receive only updates about manually stopped polls and polls, which are sent by the bot
    /// </summary>
    public Poll Poll { get; set; }

    /// <summary>
    /// Optional. A user changed their answer in a non-anonymous poll. Bots receive new votes only in polls that were sent by the bot itself.
    /// </summary>
    public PollAnswer PollAnswer { get; set; }

    /// <summary>
    /// Optional. The bot's chat member status was updated in a chat. For private chats, 
    /// this update is received only when the bot is blocked or unblocked by the user.
    /// </summary>
    public ChatMemberUpdated MyChatMember { get; set; }

    /// <summary>
    /// Optional. A chat member's status was updated in a chat.
    /// The bot must be an administrator in the chat and must explicitly specify "chat_member" in the list of allowed_updates to receive these updates.
    /// </summary>
    public ChatMemberUpdated ChatMember { get; set; }

    /// <summary>
    /// Optional. A request to join the chat has been sent.
    /// The bot must have the can_invite_users administrator right in the chat to receive these updates.
    /// </summary>
    public ChatJoinRequest ChatJoinRequest { get; set; }

    /// <summary>
    /// Optional. A chat boost was added or changed. The bot must be an administrator in the chat to receive these updates.
    /// </summary>
    public ChatBoostUpdated ChatBoost { get; set; }

    /// <summary>
    /// Optional. A boost was removed from a chat. The bot must be an administrator in the chat to receive these updates.
    /// </summary>
    public ChatBoostRemoved RemovedChatBoost { get; set; }

    #region Custom helper methods
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
    #endregion

    public static class Types
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

    public string GetUpdateType()
    {
        if (IsMessage()) { return Types.MESSAGE; }

        if (IsEditedMessage()) { return Types.EDITED_MESSAGE; }

        if (IsChannelPost()) { return Types.CHANNEL_POST; }

        if (IsEditedChannelPost()) { return Types.EDITED_CHANNEL_POST; }

        if (IsBusinessConnection()) { return Types.BUSINESS_CONNECTiON; }

        if (IsBusinessMessage()) { return Types.BUSINESS_MESSAGE; }

        if (IsEditedBusinessMessage()) { return Types.EDITED_BUSINESS_MESSAGE; }

        if (IsDeletedBusinessMessages()) { return Types.DELETED_BUSINESS_MESSAGES; }

        if (IsMessageReaction()) { return Types.MESSAGE_REACTION; }

        if (IsMessageReactionCount()) { return Types.MESSAGE_REACTION_COUNT; }

        if (IsInlineQuery()) { return Types.INLINE_QUERY; }

        if (IsChosenInlineResult()) { return Types.CHOSEN_INLINE_RESULT; }

        if (IsCallbackQuery()) { return Types.CALLBACK_QUERY; }

        if (IsShippingQuery()) { return Types.SHIPPING_QUERY; }

        if (IsPreCheckoutQuery()) { return Types.PRE_CHECKOUT_QUERY; }

        if (IsPurchasedPaidMedia()) { return Types.PURCHASED_PAID_MEDIA; }

        if (IsPoll()) { return Types.POLL; }

        if (IsPollAnswer()) { return Types.POLL_ANSWER; }

        if (IsMyChatMember()) { return Types.MY_CHAT_MEMBER; }

        if (IsChatMember()) { return Types.CHAT_MEMBER; }

        if (IsChatJoinRequest()) { return Types.CHAT_JOIN_REQUEST; }

        if (IsChatBoost()) { return Types.CHAT_BOOST; }

        if (IsRemovedChatBoost()) { return Types.REMOVED_CHAT_BOOST; }

        throw new NotSupportedException($"json: {this.Serialize()}");
    }
}
