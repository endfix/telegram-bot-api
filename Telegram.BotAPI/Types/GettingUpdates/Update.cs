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

    [JsonIgnore]
    public UpdateTypes Type => this switch
    {
        { Message: not null } => UpdateTypes.Message,
        { EditedMessage: not null } => UpdateTypes.EditedMessage,
        { ChannelPost: not null } => UpdateTypes.ChannelPost,
        { EditedChannelPost: not null } => UpdateTypes.EditedChannelPost,
        { BusinessConnection: not null } => UpdateTypes.BusinessConnection,
        { BusinessMessage: not null } => UpdateTypes.BusinessMessage,
        { EditedBusinessMessage: not null } => UpdateTypes.EditedBusinessMessage,
        { DeletedBusinessMessages: not null } => UpdateTypes.DeletedBusinessMessages,
        { MessageReaction: not null } => UpdateTypes.MessageReaction,
        { MessageReactionCount: not null } => UpdateTypes.MessageReactionCount,
        { InlineQuery: not null } => UpdateTypes.InlineQuery,
        { ChosenInlineResult: not null } => UpdateTypes.ChosenInlineResult,
        { CallbackQuery: not null } => UpdateTypes.CallbackQuery,
        { ShippingQuery: not null } => UpdateTypes.ShippingQuery,
        { PreCheckoutQuery: not null } => UpdateTypes.PreCheckoutQuery,
        { PurchasedPaidMedia: not null } => UpdateTypes.PurchasedPaidMedia,
        { Poll: not null } => UpdateTypes.Poll,
        { PollAnswer: not null } => UpdateTypes.PollAnswer,
        { MyChatMember: not null } => UpdateTypes.MyChatMember,
        { ChatMember: not null } => UpdateTypes.ChatMember,
        { ChatJoinRequest: not null } => UpdateTypes.ChatJoinRequest,
        { ChatBoost: not null } => UpdateTypes.ChatBoost,
        { RemovedChatBoost: not null } => UpdateTypes.RemovedChatBoost,
        _ => UpdateTypes.Unknown
    };
}
