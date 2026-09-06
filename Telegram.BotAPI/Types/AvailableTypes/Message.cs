using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Represents a Telegram message.</summary>
public sealed class Message : MaybeInaccessibleMessage
{
    /// <summary>Unique identifier of the message thread or forum topic to which the message belongs, if available.</summary>
    public long? MessageThreadId { get; init; }

    /// <summary>Information about the direct messages chat topic that contains the message, if available.</summary>
    public DirectMessagesTopic? DirectMessagesTopic { get; init; }

    /// <summary>Sender of the message, if available.</summary>
    public User? From { get; init; }

    /// <summary>Sender of the message when sent on behalf of a chat, if available.</summary>
    public Chat? SenderChat { get; init; }

    /// <summary>Number of boosts added by the sender, if the sender boosted the chat.</summary>
    public int? SenderBoostCount { get; init; }

    /// <summary>The bot that actually sent the message on behalf of a business account, if available.</summary>
    public User? SenderBusinessBot { get; init; }

    /// <summary>Tag or custom title of the sender, for supergroups.</summary>
    public string? SenderTag { get; init; }

    /// <summary>The user who received an ephemeral message, if applicable.</summary>
    public User? ReceiverUser { get; init; }

    /// <summary>Identifier of an ephemeral message inside this chat, if applicable.</summary>
    public long? EphemeralMessageId { get; init; }

    /// <summary>Unique identifier of the guest query, if applicable.</summary>
    public string? GuestQueryId { get; init; }

    /// <summary>Unique identifier of the business connection from which the message was received, if applicable.</summary>
    public string? BusinessConnectionId { get; init; }

    /// <summary>Information about the original message for a forwarded message, if available.</summary>
    public MessageOrigin? ForwardOrigin { get; init; }

    /// <summary>Indicates whether the message was sent to a topic in a forum supergroup or a private chat with the bot.</summary>
    public bool? IsTopicMessage { get; init; }

    /// <summary>Indicates whether the message is a channel post automatically forwarded to the connected discussion group.</summary>
    public bool? IsAutomaticForward { get; init; }

    /// <summary>The original message for a reply in the same chat and message thread, if available.</summary>
    public Message? ReplyToMessage { get; init; }

    /// <summary>Information about a message being replied to from another chat or forum topic, if available.</summary>
    public ExternalReplyInfo? ExternalReply { get; init; }

    /// <summary>The quoted part of the original message, if the message is a reply that quotes it.</summary>
    public TextQuote? Quote { get; init; }

    /// <summary>The original story for a reply to a story, if available.</summary>
    public Story? ReplyToStory { get; init; }

    public int? ReplyToChecklistTaskId { get; init; }

    public string? ReplyToPollOptionId { get; init; }

    public User? ViaBot { get; init; }

    public User? GuestBotCallerUser { get; init; }

    public Chat? GuestBotCallerChat { get; init; }

    public int? EditDate { get; init; }

    public bool? HasProtectedContent { get; init; }

    public bool? IsFromOffline { get; init; }

    public bool? IsPaidPost { get; init; }

    public string? MediaGroupId { get; init; }

    public string? AuthorSignature { get; init; }

    public int? PaidStarCount { get; init; }

    public string? Text { get; init; }

    public IReadOnlyList<MessageEntity>? Entities { get; init; }

    public LinkPreviewOptions? LinkPreviewOptions { get; init; }

    public SuggestedPostInfo? SuggestedPostInfo { get; init; }

    public string? EffectId { get; init; }

    public RichMessage? RichMessage { get; init; }

    public Animation? Animation { get; init; }

    public Audio? Audio { get; init; }

    public Document? Document { get; init; }

    public LivePhoto? LivePhoto { get; init; }

    public PaidMediaInfo? PaidMedia { get; init; }

    public IReadOnlyList<PhotoSize>? Photo { get; init; }

    public Sticker? Sticker { get; init; }

    public Story? Story { get; init; }

    public Video? Video { get; init; }

    public VideoNote? VideoNote { get; init; }

    public Voice? Voice { get; init; }

    public string? Caption { get; init; }

    public IReadOnlyList<MessageEntity>? CaptionEntities { get; init; }

    public bool? ShowCaptionAboveMedia { get; init; }

    public bool? HasMediaSpoiler { get; init; }

    public Checklist? Checklist { get; init; }

    public Contact? Contact { get; init; }

    public Dice? Dice { get; init; }

    public Game? Game { get; init; }

    public Poll? Poll { get; init; }

    public Venue? Venue { get; init; }

    public Location? Location { get; init; }

    public IReadOnlyList<User>? NewChatMembers { get; init; }

    public User? LeftChatMember { get; init; }

    public ChatOwnerLeft? ChatOwnerLeft { get; init; }

    public ChatOwnerChanged? ChatOwnerChanged { get; init; }

    public string? NewChatTitle { get; init; }

    public IReadOnlyList<PhotoSize>? NewChatPhoto { get; init; }

    public bool? DeleteChatPhoto { get; init; }

    public bool? GroupChatCreated { get; init; }

    public bool? SupergroupChatCreated { get; init; }

    public bool? ChannelChatCreated { get; init; }

    public MessageAutoDeleteTimerChanged? MessageAutoDeleteTimerChanged { get; init; }

    public long? MigrateToChatId { get; init; }

    public long? MigrateFromChatId { get; init; }

    public MaybeInaccessibleMessage? PinnedMessage { get; init; }

    public Invoice? Invoice { get; init; }

    public SuccessfulPayment? SuccessfulPayment { get; init; }

    public RefundedPayment? RefundedPayment { get; init; }

    public UsersShared? UsersShared { get; init; }

    public ChatShared? ChatShared { get; init; }

    public GiftInfo? Gift { get; init; }

    public UniqueGiftInfo? UniqueGift { get; init; }

    public GiftInfo? GiftUpgradeSent { get; init; }

    public string? ConnectedWebsite { get; init; }

    public WriteAccessAllowed? WriteAccessAllowed { get; init; }

    public PassportData? PassportData { get; init; }

    public ProximityAlertTriggered? ProximityAlertTriggered { get; init; }

    public ChatBoostAdded? BoostAdded { get; init; }

    public ChatBackground? ChatBackgroundSet { get; init; }

    public ChecklistTasksDone? ChecklistTasksDone { get; init; }

    public ChecklistTasksAdded? ChecklistTasksAdded { get; init; }

    public CommunityChatAdded? CommunityChatAdded { get; init; }

    public CommunityChatJoined? CommunityChatJoined { get; init; }

    public CommunityChatRemoved? CommunityChatRemoved { get; init; }

    public DirectMessagePriceChanged? DirectMessagePriceChanged { get; init; }

    public ForumTopicCreated? ForumTopicCreated { get; init; }

    public ForumTopicEdited? ForumTopicEdited { get; init; }

    public ForumTopicClosed? ForumTopicClosed { get; init; }

    public ForumTopicReopened? ForumTopicReopened { get; init; }

    public GeneralForumTopicHidden? GeneralForumTopicHidden { get; init; }

    public GeneralForumTopicUnhidden? GeneralForumTopicUnhidden { get; init; }

    public GiveawayCreated? GiveawayCreated { get; init; }

    public Giveaway? Giveaway { get; init; }

    public GiveawayWinners? GiveawayWinners { get; init; }

    public GiveawayCompleted? GiveawayCompleted { get; init; }

    public ManagedBotCreated? ManagedBotCreated { get; init; }

    public PaidMessagePriceChanged? PaidMessagePriceChanged { get; init; }

    public PollOptionAdded? PollOptionAdded { get; init; }

    public PollOptionDeleted? PollOptionDeleted { get; init; }

    public SuggestedPostApproved? SuggestedPostApproved { get; init; }

    public SuggestedPostApprovalFailed? SuggestedPostApprovalFailed { get; init; }

    public SuggestedPostDeclined? SuggestedPostDeclined { get; init; }

    public SuggestedPostPaid? SuggestedPostPaid { get; init; }

    public SuggestedPostRefunded? SuggestedPostRefunded { get; init; }

    public VideoChatScheduled? VideoChatScheduled { get; init; }

    public VideoChatStarted? VideoChatStarted { get; init; }

    public VideoChatEnded? VideoChatEnded { get; init; }

    public VideoChatParticipantsInvited? VideoChatParticipantsInvited { get; init; }

    public WebAppData? WebAppData { get; init; }

    public InlineKeyboardMarkup? ReplyMarkup { get; init; }
}
