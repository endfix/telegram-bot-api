using System.Text.Json.Serialization;
using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

public sealed class Update
{
    public required long UpdateId { get; init; }

    public Message? Message { get; init; }

    public Message? EditedMessage { get; init; }

    public Message? ChannelPost { get; init; }

    public Message? EditedChannelPost { get; init; }

    public BusinessConnection? BusinessConnection { get; init; }

    public Message? BusinessMessage { get; init; }

    public Message? EditedBusinessMessage { get; init; }

    public BusinessMessagesDeleted? DeletedBusinessMessages { get; init; }

    public Message? GuestMessage { get; init; }

    public MessageReactionUpdated? MessageReaction { get; init; }

    public MessageReactionCountUpdated? MessageReactionCount { get; init; }

    public InlineQuery? InlineQuery { get; init; }

    public ChosenInlineResult? ChosenInlineResult { get; init; }

    public CallbackQuery? CallbackQuery { get; init; }

    public ShippingQuery? ShippingQuery { get; init; }

    public PreCheckoutQuery? PreCheckoutQuery { get; init; }

    public PaidMediaPurchased? PurchasedPaidMedia { get; init; }

    public Poll? Poll { get; init; }

    public PollAnswer? PollAnswer { get; init; }

    public ChatMemberUpdated? MyChatMember { get; init; }

    public ChatMemberUpdated? ChatMember { get; init; }

    public ChatJoinRequest? ChatJoinRequest { get; init; }

    public ChatBoostUpdated? ChatBoost { get; init; }

    public ChatBoostRemoved? RemovedChatBoost { get; init; }

    public ManagedBotUpdated? ManagedBot { get; init; }

    public BotSubscriptionUpdated? Subscription { get; init; }

    [JsonIgnore]
    public UpdateType Type => this switch
    {
        { Message: not null } => UpdateType.Message,
        { EditedMessage: not null } => UpdateType.EditedMessage,
        { ChannelPost: not null } => UpdateType.ChannelPost,
        { EditedChannelPost: not null } => UpdateType.EditedChannelPost,
        { BusinessConnection: not null } => UpdateType.BusinessConnection,
        { BusinessMessage: not null } => UpdateType.BusinessMessage,
        { EditedBusinessMessage: not null } => UpdateType.EditedBusinessMessage,
        { DeletedBusinessMessages: not null } => UpdateType.DeletedBusinessMessages,
        { MessageReaction: not null } => UpdateType.MessageReaction,
        { MessageReactionCount: not null } => UpdateType.MessageReactionCount,
        { InlineQuery: not null } => UpdateType.InlineQuery,
        { ChosenInlineResult: not null } => UpdateType.ChosenInlineResult,
        { CallbackQuery: not null } => UpdateType.CallbackQuery,
        { ShippingQuery: not null } => UpdateType.ShippingQuery,
        { PreCheckoutQuery: not null } => UpdateType.PreCheckoutQuery,
        { PurchasedPaidMedia: not null } => UpdateType.PurchasedPaidMedia,
        { Poll: not null } => UpdateType.Poll,
        { PollAnswer: not null } => UpdateType.PollAnswer,
        { MyChatMember: not null } => UpdateType.MyChatMember,
        { ChatMember: not null } => UpdateType.ChatMember,
        { ChatJoinRequest: not null } => UpdateType.ChatJoinRequest,
        { ChatBoost: not null } => UpdateType.ChatBoost,
        { RemovedChatBoost: not null } => UpdateType.RemovedChatBoost,
        { ManagedBot: not null } => UpdateType.ManagedBot,
        _ => UpdateType.Unknown
    };
}
