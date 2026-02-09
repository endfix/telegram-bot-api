using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

public sealed class ChatFullInfo
{
    public required long Id { get; set; }

    public required ChatFullInfoTypes Type { get; set; }

    public string? Title { get; set; }

    public string? Username { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public bool? IsForum { get; set; } = null;

    public bool? IsDirectMessages { get; set; } = null;

    public required int AccentColorId { get; set; }

    public required int MaxReactionCount { get; set; }

    public ChatPhoto? Photo { get; set; }

    public string[]? ActiveUsernames { get; set; }

    public Birthdate? Birthdate { get; set; }

    public BusinessIntro? BusinessIntro { get; set; }

    public BusinessLocation? BusinessLocation { get; set; }

    public BusinessOpeningHours? BusinessOpeningHours { get; set; }

    public Chat? PersonalChat { get; set; }

    public Chat? ParentChat { get; set; }

    public ReactionType[]? AvailableReactions { get; set; }

    public string? BackgroundCustomEmojiId { get; set; }

    public int? ProfileAccentColorId { get; set; } = null;

    public string? ProfileBackgroundCustomEmojiId { get; set; }

    public string? EmojiStatusCustomEmojiId { get; set; }

    public int? EmojiStatusExpirationDate { get; set; } = null;

    public string? Bio { get; set; }

    public bool? HasPrivateForwards { get; set; } = null;

    public bool? HasRestrictedVoiceAndVideoMessages { get; set; } = null;

    public bool? JoinToSendMessages { get; set; } = null;

    public bool? JoinByRequest { get; set; } = null;

    public string? Description { get; set; }

    public string? InviteLink { get; set; }

    public Message? PinnedMessage { get; set; }

    public ChatPermissions? Permissions { get; set; }

    public AcceptedGiftTypes? AcceptedGiftTypes { get; set; }

    public bool? CanSendPaidMedia { get; set; } = null;

    public int? SlowModeDelay { get; set; } = null;

    public int? UnrestrictBoostCount { get; set; } = null;

    public int? MessageAutoDeleteTime { get; set; } = null;

    public bool? HasAggressiveAntiSpamEnabled { get; set; } = null;

    public bool? HasHiddenMembers { get; set; } = null;

    public bool? HasProtectedContent { get; set; } = null;

    public bool? HasVisibleHistory { get; set; } = null;

    public string? StickerSetName { get; set; } = null;

    public bool? CanSetStickerSet { get; set; } = null;

    public bool? CustomEmojiStickerSetName { get; set; } = null;

    public int? LinkedChatId { get; set; } = null;

    public ChatLocation? Location { get; set; }

    public UserRating? Rating { get; set; }

    public Audio? FirstProfileAudio { get; set; }

    public UniqueGiftColors? UniqueGiftColors { get; set; }

    public int? PaidMessageStarCount { get; set; } = null;
}
