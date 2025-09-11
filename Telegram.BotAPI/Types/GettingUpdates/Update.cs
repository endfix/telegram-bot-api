using System.Text.Json.Serialization;
using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

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
        _ => default
    };
}
