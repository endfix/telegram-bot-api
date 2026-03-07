using System.Collections.Generic;

namespace Telegram.BotAPI.Types;

public sealed class Message : MaybeInaccessibleMessage
{
    public long? MessageThreadId { get; init; }

    public DirectMessagesTopic? DirectMessagesTopic { get; init; }

    public User? From { get; init; }

    public Chat? SenderChat { get; init; }

    public int? SenderBoostCount { get; init; }

    public User? SenderBusinessBot { get; init; }

    public string? SenderTag { get; init; }

    public string? BusinessConnectionId { get; init; }

    public MessageOrigin? ForwardOrigin { get; init; }

    public bool? IsTopicMessage { get; init; }

    public bool? IsAutomaticForward { get; init; }

    public Message? ReplyToMessage { get; init; }

    public ExternalReplyInfo? ExternalReply { get; init; }

    public TextQuote? Quote { get; init; }

    public Story? ReplyToStory { get; init; }

    public int? ReplyToChecklistTaskId { get; init; }

    public User? ViaBot { get; init; }

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

    public Animation? Animation { get; init; }

    public Audio? Audio { get; init; }

    public Document? Document { get; init; }

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

    public PaidMessagePriceChanged? PaidMessagePriceChanged { get; init; }

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
