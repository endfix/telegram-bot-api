namespace Endfix.Telegram.BotAPI.Enums;

/// <summary>Identifies the payload exposed by a Telegram update.</summary>
public enum UpdateType
{
    /// <summary>No supported update payload is present.</summary>
    Unknown,

    /// <summary>A new incoming message.</summary>
    Message,

    /// <summary>An edited version of a known message.</summary>
    EditedMessage,

    /// <summary>A new channel post.</summary>
    ChannelPost,

    /// <summary>An edited version of a known channel post.</summary>
    EditedChannelPost,

    /// <summary>A business account connection changed.</summary>
    BusinessConnection,

    /// <summary>A new message from a connected business account.</summary>
    BusinessMessage,

    /// <summary>An edited message from a connected business account.</summary>
    EditedBusinessMessage,

    /// <summary>Messages were deleted from a connected business account.</summary>
    DeletedBusinessMessages,

    /// <summary>A new message sent in guest mode.</summary>
    GuestMessage,

    /// <summary>A user's reaction to a message changed.</summary>
    MessageReaction,

    /// <summary>Anonymous reaction counts on a message changed.</summary>
    MessageReactionCount,

    /// <summary>A new inline query.</summary>
    InlineQuery,

    /// <summary>An inline query result was selected by a user.</summary>
    ChosenInlineResult,

    /// <summary>A new callback query.</summary>
    CallbackQuery,

    /// <summary>A new shipping query.</summary>
    ShippingQuery,

    /// <summary>A new pre-checkout query.</summary>
    PreCheckoutQuery,

    /// <summary>A user purchased paid media.</summary>
    PurchasedPaidMedia,

    /// <summary>A poll's state changed.</summary>
    Poll,

    /// <summary>A user changed an answer in a non-anonymous poll.</summary>
    PollAnswer,

    /// <summary>The bot's membership status in a chat changed.</summary>
    MyChatMember,

    /// <summary>Another chat member's status changed.</summary>
    ChatMember,

    /// <summary>A request to join a chat was submitted.</summary>
    ChatJoinRequest,

    /// <summary>A chat boost was added or changed.</summary>
    ChatBoost,

    /// <summary>A chat boost was removed.</summary>
    RemovedChatBoost,

    /// <summary>A managed bot was created or changed.</summary>
    ManagedBot,

    /// <summary>A user's payment subscription changed.</summary>
    Subscription,

    /// <summary>A user stopped message generation.</summary>
    StoppedMessageGeneration
}
