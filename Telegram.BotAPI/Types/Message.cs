using System.Collections.Generic;
using Telegram.BotAPI.Types.Payments;
using Telegram.BotAPI.Types.Stickers;
using Telegram.BotAPI.Types.TelegramPassport;

namespace Telegram.BotAPI.Types
{
    // https://core.telegram.org/bots/api#message
    public class Message
    {
        public long MessageId { get; set; }

        public long MessageThreadId { get; set; }

        public User From { get; set; }

        public Chat SenderChat { get; set; }

        public int SenderBoostCount { get; set; }

        public User SenderBusinessBot { get; set; }

        public int Date { get; set; }

        public string BusinessConnectionId { get; set; }

        public Chat Chat { get; set; }

        public MessageOrigin ForwardOrigin { get; set; }

        public bool IsTopicMessage { get; set; }

        public bool IsAutomaticForward { get; set; }

        public Message ReplyToMessage { get; set; }

        public ExternalReplyInfo ExternalReply { get; set; }

        public TextQuote Quote { get; set; }

        public Story ReplyToStory { get; set; }

        public User ViaBot { get; set; }

        public int EditDate { get; set; }

        public bool HasProtectedContent { get; set; }

        public bool IsFromOffline { get; set; }

        public string MediaGroupId { get; set; }

        public string AuthorSignature { get; set; }

        public string Text { get; set; }

        public List<MessageEntity> Entities { get; set; }

        public LinkPreviewOptions LinkPreviewOptions { get; set; }

        public string EffectId { get; set; }

        public Animation Animation { get; set; }

        public Audio Audio { get; set; }

        public Document Document { get; set; }

        public PaidMediaInfo PaidMedia { get; set; }

        public List<PhotoSize> Photo { get; set; }

        public Sticker Sticker { get; set; }

        public Story Story { get; set; }

        public Video Video { get; set; }

        public VideoNote VideoNote { get; set; }

        public Voice Voice { get; set; }

        public string Caption { get; set; }

        public List<MessageEntity> CaptionEntities { get; set; }

        public bool ShowCaptionAboveMedia { get; set; }

        public bool HasMediaSpoiler { get; set; }

        public Contact Contact { get; set; }

        public Dice Dice { get; set; }

        public Game Game { get; set; }

        public Poll Poll { get; set; }

        public Venue Venue { get; set; }

        public Location Location { get; set; }

        public List<User> NewChatMembers { get; set; }

        public User LeftChatMember { get; set; }

        public string NewChatTitle { get; set; }

        public List<PhotoSize> NewChatPhoto { get; set; }

        public bool DeleteChatPhoto { get; set; }

        public bool GroupChatCreated { get; set; }

        public bool SupergroupChatCreated { get; set; }

        public bool ChannelChatCreated { get; set; }

        public MessageAutoDeleteTimerChanged MessageAutoDeleteTimerChanged { get; set; }

        public long MigrateToChatId { get; set; }

        public long MigrateFromChatId { get; set; }

        // TODO: Message || MaybeInaccessibleMessage?
        // https://core.telegram.org/bots/api#maybeinaccessiblemessage
        public Message PinnedMessage { get; set; }

        public Invoice Invoice { get; set; }

        public SuccessfulPayment SuccessfulPayment { get; set; }

        public RefundedPayment RefundedPayment { get; set; }

        public UsersShared UsersShared { get; set; }

        public ChatShared ChatShared { get; set; }

        public string ConnectedWebsite { get; set; }

        public WriteAccessAllowed WriteAccessAllowed { get; set; }

        public PassportData PassportData { get; set; }

        public ProximityAlertTriggered ProximityAlertTriggered { get; set; }

        public ChatBoostAdded BoostAdded { get; set; }

        public ChatBackground ChatBackgroundSet { get; set; }

        public ForumTopicCreated ForumTopicCreated { get; set; }

        public ForumTopicEdited ForumTopicEdited { get; set; }

        public ForumTopicClosed ForumTopicClosed { get; set; }

        public ForumTopicReopened ForumTopicReopened { get; set; }

        public GeneralForumTopicHidden GeneralForumTopicHidden { get; set; }

        public GeneralForumTopicUnhidden GeneralForumTopicUnhidden { get; set; }

        public GiveawayCreated GiveawayCreated { get; set; }

        public Giveaway Giveaway { get; set; }

        public GiveawayWinners GiveawayWinners { get; set; }

        public GiveawayCompleted GiveawayCompleted { get; set; }

        public VideoChatScheduled VideoChatScheduled { get; set; }

        public VideoChatStarted VideoChatStarted { get; set; }

        public VideoChatEnded VideoChatEnded { get; set; }

        public VideoChatParticipantsInvited VideoChatParticipantsInvited { get; set; }

        public WebAppData WebAppData { get; set; }

        public InlineKeyboardMarkup ReplyMarkup { get; set; }
    }
}
