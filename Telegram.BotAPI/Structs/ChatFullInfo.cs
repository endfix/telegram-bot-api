namespace Telegram.BotAPI.Structs
{
    // https://core.telegram.org/bots/api#chatfullinfo
    public class ChatFullInfo
    {
        public long Id { get; set; }

        public string Type { get; set; }

        public string Title { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsForum { get; set; }

        public int AccentColorId { get; set; }

        public int MaxReactionCount { get; set; }

        public ChatPhoto Photo { get; set; }

        public List<string> ActiveUsernames { get; set; }

        public Birthdate Birthdate { get; set; }

        public BusinessIntro BusinessIntro { get; set; }

        public BusinessIntro BusinessLocation { get; set; }

        public BusinessOpeningHours BusinessOpeningHours { get; set; }

        public Chat PersonalChat { get; set; }

        public List<ReactionType> AvailableReactions { get; set; }

        public string BackgroundCustomEmojiId { get; set; }

        public int ProfileAccentColorId { get; set; }

        public string ProfileBackgroundCustomEmojiId { get; set; }

        public string EmojiStatusCustomEmojiId { get; set; }

        public int EmojiStatusExpirationDate { get; set; }

        public string Bio { get; set; }

        public bool HasPrivateForwards { get; set; }

        public bool HasRestrictedVoiceAndVideoMessages { get; set; }

        public bool JoinToSendMessages { get; set; }

        public bool JoinByRequest { get; set; }

        public string Description { get; set; }

        public string InviteLink { get; set; }

        public Message PinnedMessage { get; set; }

        public ChatPermissions Permissions { get; set; }

        public bool CanSendPaidMedia { get; set; }

        public int SlowModeDelay { get; set; }

        public int UnrestrictBoostCount { get; set; }

        public int MessageAutoDeleteTime { get; set; }

        public bool HasAggressiveAntiSpamEnabled { get; set; }

        public bool HasHiddenMembers { get; set; }

        public bool HasProtectedContent { get; set; }

        public bool HasVisibleHistory { get; set; }

        public string StickerSetName { get; set; }

        public bool CanSetStickerSet { get; set; }

        public bool CustomEmojiStickerSetName { get; set; }

        public int LinkedChatId { get; set; }

        public ChatLocation Location { get; set; }
    }
}
