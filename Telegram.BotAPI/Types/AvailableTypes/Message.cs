using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Represents a Telegram message.</summary>
public sealed class Message : MaybeInaccessibleMessage
{
    /// <summary>Identifier of the message thread or forum topic to which the message belongs; for supergroups and private chats only.</summary>
    public long? MessageThreadId { get; init; }

    /// <summary>Information about the direct messages chat topic that contains the message, if available.</summary>
    public DirectMessagesTopic? DirectMessagesTopic { get; init; }

    /// <summary>
    /// Sender of the message. May be absent for channel messages; in non-channel chats, messages sent on behalf
    /// of a chat contain a synthetic sender here for backward compatibility.
    /// </summary>
    public User? From { get; init; }

    /// <summary>
    /// Sender chat when the message was sent on behalf of a chat, such as an anonymous administrator's
    /// supergroup or a channel linked to a discussion group.
    /// </summary>
    public Chat? SenderChat { get; init; }

    /// <summary>Number of boosts added by the sender, if the sender boosted the chat.</summary>
    public int? SenderBoostCount { get; init; }

    /// <summary>The bot that actually sent an outgoing message on behalf of a connected business account.</summary>
    public User? SenderBusinessBot { get; init; }

    /// <summary>Tag or custom title of the sender, for supergroups.</summary>
    public string? SenderTag { get; init; }

    /// <summary>The user who received an ephemeral message, if applicable.</summary>
    public User? ReceiverUser { get; init; }

    /// <summary>Identifier of an ephemeral message inside this chat. The identifier may be reused after the message is deleted or expires.</summary>
    public long? EphemeralMessageId { get; init; }

    /// <summary>
    /// Identifier of the guest query used to answer it. When present, the message belongs to the chat where the
    /// guest bot was summoned, which may differ from another bot chat with the same identifier.
    /// </summary>
    public string? GuestQueryId { get; init; }

    /// <summary>
    /// Identifier of the business connection from which the message was received. When present, the message belongs
    /// to the corresponding business account's chat, independently of any bot chat with the same identifier.
    /// </summary>
    public string? BusinessConnectionId { get; init; }

    /// <summary>Information about the original message for a forwarded message, if available.</summary>
    public MessageOrigin? ForwardOrigin { get; init; }

    /// <summary>Indicates whether the message was sent to a topic in a forum supergroup or a private chat with the bot.</summary>
    public bool? IsTopicMessage { get; init; }

    /// <summary>Indicates whether the message is a channel post automatically forwarded to the connected discussion group.</summary>
    public bool? IsAutomaticForward { get; init; }

    /// <summary>
    /// Original message for a reply in the same chat and message thread. It does not contain another
    /// <see cref="ReplyToMessage"/> value and may be absent for a reply to an ephemeral message.
    /// </summary>
    public Message? ReplyToMessage { get; init; }

    /// <summary>Information about a message being replied to from another chat or forum topic, if available.</summary>
    public ExternalReplyInfo? ExternalReply { get; init; }

    /// <summary>The quoted part of the original message, if the message is a reply that quotes it.</summary>
    public TextQuote? Quote { get; init; }

    /// <summary>The original story for a reply to a story, if available.</summary>
    public Story? ReplyToStory { get; init; }

    /// <summary>Identifier of the checklist task to which the message replies, if applicable.</summary>
    public int? ReplyToChecklistTaskId { get; init; }

    /// <summary>Persistent identifier of the poll option to which the message replies, if applicable.</summary>
    public string? ReplyToPollOptionId { get; init; }

    /// <summary>Bot through which the message was sent, if applicable.</summary>
    public User? ViaBot { get; init; }

    /// <summary>For a guest-bot message, the user whose original message triggered the response.</summary>
    public User? GuestBotCallerUser { get; init; }

    /// <summary>For a guest-bot message, the chat whose original message triggered the response.</summary>
    public Chat? GuestBotCallerChat { get; init; }

    /// <summary>Date when the message was last edited, expressed as Unix time.</summary>
    public int? EditDate { get; init; }

    /// <summary><see langword="true"/> when the message cannot be forwarded.</summary>
    public bool? HasProtectedContent { get; init; }

    /// <summary><see langword="true"/> when an implicit action sent the message, such as an away, greeting, or scheduled message.</summary>
    public bool? IsFromOffline { get; init; }

    /// <summary><see langword="true"/> for a paid post, which cannot be edited and must not be deleted for 24 hours to receive payment.</summary>
    public bool? IsPaidPost { get; init; }

    /// <summary>Identifier, unique within the chat, of the media group to which the message belongs.</summary>
    public string? MediaGroupId { get; init; }

    /// <summary>Post author's signature in a channel, or an anonymous group administrator's custom title.</summary>
    public string? AuthorSignature { get; init; }

    /// <summary>Number of Telegram Stars paid by the sender to send the message.</summary>
    public int? PaidStarCount { get; init; }

    /// <summary>Actual UTF-8 text of a text message.</summary>
    public string? Text { get; init; }

    /// <summary>Special entities, such as usernames, URLs, and bot commands, that appear in <see cref="Text"/>.</summary>
    public IReadOnlyList<MessageEntity>? Entities { get; init; }

    /// <summary>Link preview options when they were changed for a text message.</summary>
    public LinkPreviewOptions? LinkPreviewOptions { get; init; }

    /// <summary>Suggested-post parameters for a message in a channel direct messages chat. Approved or declined suggested posts cannot be edited.</summary>
    public SuggestedPostInfo? SuggestedPostInfo { get; init; }

    /// <summary>Identifier of the effect added to the message.</summary>
    public string? EffectId { get; init; }

    /// <summary>Rich formatted content when the message is a rich message.</summary>
    public RichMessage? RichMessage { get; init; }

    /// <summary>Animation contained in the message. For backward compatibility, <see cref="Document"/> is also populated.</summary>
    public Animation? Animation { get; init; }

    /// <summary>Audio file contained in the message.</summary>
    public Audio? Audio { get; init; }

    /// <summary>General file contained in the message.</summary>
    public Document? Document { get; init; }

    /// <summary>Live photo contained in the message. For backward compatibility, <see cref="Photo"/> is also populated.</summary>
    public LivePhoto? LivePhoto { get; init; }

    /// <summary>Information about paid media contained in the message.</summary>
    public PaidMediaInfo? PaidMedia { get; init; }

    /// <summary>Available sizes when the message contains a photo.</summary>
    public IReadOnlyList<PhotoSize>? Photo { get; init; }

    /// <summary>Sticker contained in the message.</summary>
    public Sticker? Sticker { get; init; }

    /// <summary>Story forwarded by the message.</summary>
    public Story? Story { get; init; }

    /// <summary>Video contained in the message.</summary>
    public Video? Video { get; init; }

    /// <summary>Video note contained in the message.</summary>
    public VideoNote? VideoNote { get; init; }

    /// <summary>Voice message contained in the message.</summary>
    public Voice? Voice { get; init; }

    /// <summary>Caption for an animation, audio, document, paid media, photo, video, or voice message.</summary>
    public string? Caption { get; init; }

    /// <summary>Special entities, such as usernames, URLs, and bot commands, that appear in <see cref="Caption"/>.</summary>
    public IReadOnlyList<MessageEntity>? CaptionEntities { get; init; }

    /// <summary><see langword="true"/> when the caption is shown above the message media.</summary>
    public bool? ShowCaptionAboveMedia { get; init; }

    /// <summary><see langword="true"/> when the message media is covered by a spoiler animation.</summary>
    public bool? HasMediaSpoiler { get; init; }

    /// <summary>Checklist contained in the message.</summary>
    public Checklist? Checklist { get; init; }

    /// <summary>Contact shared in the message.</summary>
    public Contact? Contact { get; init; }

    /// <summary>Dice with a random value contained in the message.</summary>
    public Dice? Dice { get; init; }

    /// <summary>Game contained in the message.</summary>
    public Game? Game { get; init; }

    /// <summary>Native poll contained in the message.</summary>
    public Poll? Poll { get; init; }

    /// <summary>Venue contained in the message. For backward compatibility, <see cref="Location"/> is also populated.</summary>
    public Venue? Venue { get; init; }

    /// <summary>Location shared in the message.</summary>
    public Location? Location { get; init; }

    /// <summary>Members added to the group or supergroup; the bot itself may be included.</summary>
    public IReadOnlyList<User>? NewChatMembers { get; init; }

    /// <summary>Member removed from the group; this may be the bot itself.</summary>
    public User? LeftChatMember { get; init; }

    /// <summary>Service-message information indicating that the chat owner left.</summary>
    public ChatOwnerLeft? ChatOwnerLeft { get; init; }

    /// <summary>Service-message information about a change of chat owner.</summary>
    public ChatOwnerChanged? ChatOwnerChanged { get; init; }

    /// <summary>New chat title when the title was changed.</summary>
    public string? NewChatTitle { get; init; }

    /// <summary>Available sizes of the new chat photo when it was changed.</summary>
    public IReadOnlyList<PhotoSize>? NewChatPhoto { get; init; }

    /// <summary><see langword="true"/> for a service message indicating that the chat photo was deleted.</summary>
    public bool? DeleteChatPhoto { get; init; }

    /// <summary><see langword="true"/> for a service message indicating that the group was created.</summary>
    public bool? GroupChatCreated { get; init; }

    /// <summary>
    /// <see langword="true"/> for a service message indicating that the supergroup was created. This field is
    /// available only through <see cref="ReplyToMessage"/> because a bot cannot be a member when the supergroup is created.
    /// </summary>
    public bool? SupergroupChatCreated { get; init; }

    /// <summary>
    /// <see langword="true"/> for a service message indicating that the channel was created. This field is
    /// available only through <see cref="ReplyToMessage"/> because a bot cannot be a member when the channel is created.
    /// </summary>
    public bool? ChannelChatCreated { get; init; }

    /// <summary>Service-message information about a change to the chat's auto-delete timer.</summary>
    public MessageAutoDeleteTimerChanged? MessageAutoDeleteTimerChanged { get; init; }

    /// <summary>Identifier of the supergroup to which the group was migrated.</summary>
    public long? MigrateToChatId { get; init; }

    /// <summary>Identifier of the group from which the supergroup was migrated.</summary>
    public long? MigrateFromChatId { get; init; }

    /// <summary>The message that was pinned. A regular message in this field does not contain nested reply information.</summary>
    public MaybeInaccessibleMessage? PinnedMessage { get; init; }

    /// <summary>Invoice contained in the message.</summary>
    public Invoice? Invoice { get; init; }

    /// <summary>Information from a service message about a successful payment.</summary>
    public SuccessfulPayment? SuccessfulPayment { get; init; }

    /// <summary>Information from a service message about a refunded payment.</summary>
    public RefundedPayment? RefundedPayment { get; init; }

    /// <summary>Information from a service message about users shared with the bot.</summary>
    public UsersShared? UsersShared { get; init; }

    /// <summary>Information from a service message about a chat shared with the bot.</summary>
    public ChatShared? ChatShared { get; init; }

    /// <summary>Information from a service message about a regular gift that was sent or received.</summary>
    public GiftInfo? Gift { get; init; }

    /// <summary>Information from a service message about a unique gift that was sent or received.</summary>
    public UniqueGiftInfo? UniqueGift { get; init; }

    /// <summary>Information from a service message indicating that an upgrade was purchased after a gift was sent.</summary>
    public GiftInfo? GiftUpgradeSent { get; init; }

    /// <summary>Domain name of the website on which the user logged in through Telegram Login.</summary>
    public string? ConnectedWebsite { get; init; }

    /// <summary>Information from a service message indicating that the user allowed the bot to send messages.</summary>
    public WriteAccessAllowed? WriteAccessAllowed { get; init; }

    /// <summary>Telegram Passport data contained in the message.</summary>
    public PassportData? PassportData { get; init; }

    /// <summary>Information from a service message indicating that a user triggered another user's proximity alert while sharing a live location.</summary>
    public ProximityAlertTriggered? ProximityAlertTriggered { get; init; }

    /// <summary>Information from a service message indicating that a user boosted the chat.</summary>
    public ChatBoostAdded? BoostAdded { get; init; }

    /// <summary>Information from a service message indicating that the chat background was changed.</summary>
    public ChatBackground? ChatBackgroundSet { get; init; }

    /// <summary>Information from a service message about checklist tasks marked as done or not done.</summary>
    public ChecklistTasksDone? ChecklistTasksDone { get; init; }

    /// <summary>Information from a service message about tasks added to a checklist.</summary>
    public ChecklistTasksAdded? ChecklistTasksAdded { get; init; }

    /// <summary>Information from a service message indicating that a chat or bot was added to a community.</summary>
    public CommunityChatAdded? CommunityChatAdded { get; init; }

    /// <summary>Information from a service message indicating that a user joined a chat from a community.</summary>
    public CommunityChatJoined? CommunityChatJoined { get; init; }

    /// <summary>Information from a service message indicating that a chat or bot was removed from a community.</summary>
    public CommunityChatRemoved? CommunityChatRemoved { get; init; }

    /// <summary>Information from a service message about a paid-message price change in a channel's direct messages chat.</summary>
    public DirectMessagePriceChanged? DirectMessagePriceChanged { get; init; }

    /// <summary>Information from a service message about a newly created forum topic.</summary>
    public ForumTopicCreated? ForumTopicCreated { get; init; }

    /// <summary>Information from a service message about an edited forum topic.</summary>
    public ForumTopicEdited? ForumTopicEdited { get; init; }

    /// <summary>Information from a service message about a closed forum topic.</summary>
    public ForumTopicClosed? ForumTopicClosed { get; init; }

    /// <summary>Information from a service message about a reopened forum topic.</summary>
    public ForumTopicReopened? ForumTopicReopened { get; init; }

    /// <summary>Information from a service message indicating that the General forum topic was hidden.</summary>
    public GeneralForumTopicHidden? GeneralForumTopicHidden { get; init; }

    /// <summary>Information from a service message indicating that the General forum topic was unhidden.</summary>
    public GeneralForumTopicUnhidden? GeneralForumTopicUnhidden { get; init; }

    /// <summary>Information from a service message about a newly scheduled giveaway.</summary>
    public GiveawayCreated? GiveawayCreated { get; init; }

    /// <summary>Scheduled giveaway contained in the message.</summary>
    public Giveaway? Giveaway { get; init; }

    /// <summary>Information about a completed giveaway with public winners.</summary>
    public GiveawayWinners? GiveawayWinners { get; init; }

    /// <summary>Information from a service message about a completed giveaway without public winners.</summary>
    public GiveawayCompleted? GiveawayCompleted { get; init; }

    /// <summary>Information from a service message indicating that a user created a bot managed by the current bot.</summary>
    public ManagedBotCreated? ManagedBotCreated { get; init; }

    /// <summary>Information from a service message about a change to the chat's paid-message price.</summary>
    public PaidMessagePriceChanged? PaidMessagePriceChanged { get; init; }

    /// <summary>Information from a service message about an answer option added to a poll.</summary>
    public PollOptionAdded? PollOptionAdded { get; init; }

    /// <summary>Information from a service message about an answer option deleted from a poll.</summary>
    public PollOptionDeleted? PollOptionDeleted { get; init; }

    /// <summary>Information from a service message about an approved suggested post.</summary>
    public SuggestedPostApproved? SuggestedPostApproved { get; init; }

    /// <summary>Information from a service message about a failed suggested-post approval.</summary>
    public SuggestedPostApprovalFailed? SuggestedPostApprovalFailed { get; init; }

    /// <summary>Information from a service message about a declined suggested post.</summary>
    public SuggestedPostDeclined? SuggestedPostDeclined { get; init; }

    /// <summary>Information from a service message indicating that payment for a suggested post was received.</summary>
    public SuggestedPostPaid? SuggestedPostPaid { get; init; }

    /// <summary>Information from a service message indicating that payment for a suggested post was refunded.</summary>
    public SuggestedPostRefunded? SuggestedPostRefunded { get; init; }

    /// <summary>Information from a service message about a scheduled video chat.</summary>
    public VideoChatScheduled? VideoChatScheduled { get; init; }

    /// <summary>Information from a service message indicating that a video chat started.</summary>
    public VideoChatStarted? VideoChatStarted { get; init; }

    /// <summary>Information from a service message indicating that a video chat ended.</summary>
    public VideoChatEnded? VideoChatEnded { get; init; }

    /// <summary>Information from a service message about participants invited to a video chat.</summary>
    public VideoChatParticipantsInvited? VideoChatParticipantsInvited { get; init; }

    /// <summary>Data sent by a Web App in a service message.</summary>
    public WebAppData? WebAppData { get; init; }

    /// <summary>Inline keyboard attached to the message. Login URL buttons are represented as ordinary URL buttons.</summary>
    public InlineKeyboardMarkup? ReplyMarkup { get; init; }
}
