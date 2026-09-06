using System.Text.Json.Serialization;
using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Represents an incoming Telegram update.</summary>
/// <remarks>At most one of the optional update payloads can be present in a given update.</remarks>
public sealed class Update
{
    /// <summary>Unique identifier for this update. Update identifiers increase sequentially, except after a week without new updates.</summary>
    public required long UpdateId { get; init; }

    /// <summary>New incoming message of any kind, if present.</summary>
    public Message? Message { get; init; }

    /// <summary>New version of a message that is known to the bot and was edited, if present.</summary>
    public Message? EditedMessage { get; init; }

    /// <summary>New incoming channel post of any kind, if present.</summary>
    public Message? ChannelPost { get; init; }

    /// <summary>New version of a channel post that is known to the bot and was edited, if present.</summary>
    public Message? EditedChannelPost { get; init; }

    /// <summary>Business connection update, if present.</summary>
    public BusinessConnection? BusinessConnection { get; init; }

    /// <summary>New message from a connected business account, if present.</summary>
    public Message? BusinessMessage { get; init; }

    /// <summary>New version of a message from a connected business account, if present.</summary>
    public Message? EditedBusinessMessage { get; init; }

    /// <summary>Notification that messages were deleted from a connected business account, if present.</summary>
    public BusinessMessagesDeleted? DeletedBusinessMessages { get; init; }

    /// <summary>New guest message, if present.</summary>
    public Message? GuestMessage { get; init; }

    /// <summary>Update about a user's reaction to a message, if present.</summary>
    public MessageReactionUpdated? MessageReaction { get; init; }

    /// <summary>Update about anonymous reaction counts on a message, if present.</summary>
    public MessageReactionCountUpdated? MessageReactionCount { get; init; }

    /// <summary>New incoming inline query, if present.</summary>
    public InlineQuery? InlineQuery { get; init; }

    /// <summary>Inline result chosen by a user, if present.</summary>
    public ChosenInlineResult? ChosenInlineResult { get; init; }

    /// <summary>New incoming callback query, if present.</summary>
    public CallbackQuery? CallbackQuery { get; init; }

    /// <summary>New incoming shipping query, if present.</summary>
    public ShippingQuery? ShippingQuery { get; init; }

    /// <summary>New incoming pre-checkout query, if present.</summary>
    public PreCheckoutQuery? PreCheckoutQuery { get; init; }

    /// <summary>Notification that a user purchased paid media, if present.</summary>
    public PaidMediaPurchased? PurchasedPaidMedia { get; init; }

    /// <summary>New poll state, if present.</summary>
    public Poll? Poll { get; init; }

    /// <summary>Update about a user's answer in a non-anonymous poll, if present.</summary>
    public PollAnswer? PollAnswer { get; init; }

    /// <summary>Update about the bot's membership status in a chat, if present.</summary>
    public ChatMemberUpdated? MyChatMember { get; init; }

    /// <summary>Update about another member's status in a chat, if present.</summary>
    public ChatMemberUpdated? ChatMember { get; init; }

    /// <summary>New request to join a chat, if present.</summary>
    public ChatJoinRequest? ChatJoinRequest { get; init; }

    /// <summary>Update about a chat boost, if present.</summary>
    public ChatBoostUpdated? ChatBoost { get; init; }

    /// <summary>Update about a removed chat boost, if present.</summary>
    public ChatBoostRemoved? RemovedChatBoost { get; init; }

    /// <summary>Update about a managed bot being created or changed, if present.</summary>
    public ManagedBotUpdated? ManagedBot { get; init; }

    /// <summary>Update about a user's payment subscription, if present.</summary>
    public BotSubscriptionUpdated? Subscription { get; init; }

    /// <summary>Update about a user stopping message generation, if present.</summary>
    public MessageGenerationStopped? StoppedMessageGeneration { get; init; }

    /// <summary>Gets the payload kind detected from the first populated update field.</summary>
    /// <remarks>Returns <see cref="UpdateType.Unknown"/> when no known payload is present.</remarks>
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
        { Subscription: not null } => UpdateType.Subscription,
        { StoppedMessageGeneration: not null } => UpdateType.StoppedMessageGeneration,
        _ => UpdateType.Unknown
    };
}
