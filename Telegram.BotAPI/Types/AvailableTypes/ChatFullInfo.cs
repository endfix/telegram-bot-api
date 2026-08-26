using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

public sealed class ChatFullInfo
{
    public required long Id { get; init; }

    public required ChatFullInfoTypes Type { get; init; }

    public string? Title { get; init; }

    public string? Username { get; init; }

    public string? FirstName { get; init; }

    public string? LastName { get; init; }

    public bool? IsForum { get; init; }

    public bool? IsDirectMessages { get; init; }

    public required int AccentColorId { get; init; }

    public required int MaxReactionCount { get; init; }

    public ChatPhoto? Photo { get; init; }

    public IReadOnlyList<string>? ActiveUsernames { get; init; }

    public Birthdate? Birthdate { get; init; }

    public BusinessIntro? BusinessIntro { get; init; }

    public BusinessLocation? BusinessLocation { get; init; }

    public BusinessOpeningHours? BusinessOpeningHours { get; init; }

    public Chat? PersonalChat { get; init; }

    public Chat? ParentChat { get; init; }

    public IReadOnlyList<ReactionType>? AvailableReactions { get; init; }

    public string? BackgroundCustomEmojiId { get; init; }

    public int? ProfileAccentColorId { get; init; }

    public string? ProfileBackgroundCustomEmojiId { get; init; }

    public string? EmojiStatusCustomEmojiId { get; init; }

    public int? EmojiStatusExpirationDate { get; init; }

    public string? Bio { get; init; }

    public bool? HasPrivateForwards { get; init; }

    public bool? HasRestrictedVoiceAndVideoMessages { get; init; }

    public bool? JoinToSendMessages { get; init; }

    public bool? JoinByRequest { get; init; }

    public string? Description { get; init; }

    public string? InviteLink { get; init; }

    public Message? PinnedMessage { get; init; }

    public ChatPermissions? Permissions { get; init; }

    public required AcceptedGiftTypes AcceptedGiftTypes { get; init; }

    public bool? CanSendPaidMedia { get; init; }

    public int? SlowModeDelay { get; init; }

    public int? UnrestrictBoostCount { get; init; }

    public int? MessageAutoDeleteTime { get; init; }

    public bool? HasAggressiveAntiSpamEnabled { get; init; }

    public bool? HasHiddenMembers { get; init; }

    public bool? HasProtectedContent { get; init; }

    public bool? HasVisibleHistory { get; init; }

    public string? StickerSetName { get; init; }

    public bool? CanSetStickerSet { get; init; }

    public bool? CustomEmojiStickerSetName { get; init; }

    public long? LinkedChatId { get; init; }

    public ChatLocation? Location { get; init; }

    public UserRating? Rating { get; init; }

    public Audio? FirstProfileAudio { get; init; }

    public UniqueGiftColors? UniqueGiftColors { get; init; }

    public int? PaidMessageStarCount { get; init; }

    public User? GuardBot { get; init; }

    public Community? Community { get; init; }
}
