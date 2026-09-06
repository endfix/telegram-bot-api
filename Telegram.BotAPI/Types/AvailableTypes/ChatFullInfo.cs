using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Contains full information about a chat.</summary>
public sealed class ChatFullInfo
{
    /// <summary>Unique identifier for this chat.</summary>
    public required long Id { get; init; }

    /// <summary>Type of the chat.</summary>
    public required ChatFullInfoTypes Type { get; init; }

    /// <summary>Title of the chat, if available.</summary>
    public string? Title { get; init; }

    /// <summary>Username of the chat, if available.</summary>
    public string? Username { get; init; }

    /// <summary>First name of the other party in a private chat, if available.</summary>
    public string? FirstName { get; init; }

    /// <summary>Last name of the other party in a private chat, if available.</summary>
    public string? LastName { get; init; }

    /// <summary>Indicates whether the supergroup is a forum.</summary>
    public bool? IsForum { get; init; }

    /// <summary>Indicates whether this is the direct messages chat of a channel.</summary>
    public bool? IsDirectMessages { get; init; }

    /// <summary>Identifier of the accent color for the chat name and related backgrounds.</summary>
    public required int AccentColorId { get; init; }

    /// <summary>Maximum number of reactions that can be set on a message in the chat.</summary>
    public required int MaxReactionCount { get; init; }

    /// <summary>Chat photo, if available.</summary>
    public ChatPhoto? Photo { get; init; }

    /// <summary>All active usernames of the chat, if available.</summary>
    public IReadOnlyList<string>? ActiveUsernames { get; init; }

    /// <summary>Date of birth of the user in a private chat, if available.</summary>
    public Birthdate? Birthdate { get; init; }

    /// <summary>Business account intro, if available.</summary>
    public BusinessIntro? BusinessIntro { get; init; }

    /// <summary>Business account location, if available.</summary>
    public BusinessLocation? BusinessLocation { get; init; }

    /// <summary>Business account opening hours, if available.</summary>
    public BusinessOpeningHours? BusinessOpeningHours { get; init; }

    /// <summary>Personal channel of the user in a private chat, if available.</summary>
    public Chat? PersonalChat { get; init; }

    /// <summary>Corresponding channel chat for a direct messages chat, if available.</summary>
    public Chat? ParentChat { get; init; }

    /// <summary>Reactions allowed in the chat, if explicitly restricted.</summary>
    public IReadOnlyList<ReactionType>? AvailableReactions { get; init; }

    /// <summary>Custom emoji used for the chat background, if available.</summary>
    public string? BackgroundCustomEmojiId { get; init; }

    /// <summary>Identifier of the profile background accent color, if available.</summary>
    public int? ProfileAccentColorId { get; init; }

    /// <summary>Custom emoji used for the profile background, if available.</summary>
    public string? ProfileBackgroundCustomEmojiId { get; init; }

    /// <summary>Custom emoji identifier of the chat's emoji status, if available.</summary>
    public string? EmojiStatusCustomEmojiId { get; init; }

    /// <summary>Expiration date of the emoji status in Unix time, if available.</summary>
    public int? EmojiStatusExpirationDate { get; init; }

    /// <summary>Bio of the other party in a private chat, if available.</summary>
    public string? Bio { get; init; }

    /// <summary>Indicates whether the other party's privacy settings allow private-forwards links.</summary>
    public bool? HasPrivateForwards { get; init; }

    /// <summary>Indicates whether the other party restricts voice and video note messages.</summary>
    public bool? HasRestrictedVoiceAndVideoMessages { get; init; }

    /// <summary>Indicates whether users must join the supergroup before sending messages.</summary>
    public bool? JoinToSendMessages { get; init; }

    /// <summary>Indicates whether users joining directly must be approved by administrators.</summary>
    public bool? JoinByRequest { get; init; }

    /// <summary>Description of the group, supergroup or channel, if available.</summary>
    public string? Description { get; init; }

    /// <summary>Primary invite link, if available.</summary>
    public string? InviteLink { get; init; }

    /// <summary>Most recent pinned message, if available.</summary>
    public Message? PinnedMessage { get; init; }

    /// <summary>Default member permissions, if available.</summary>
    public ChatPermissions? Permissions { get; init; }

    /// <summary>Types of gifts accepted by the chat.</summary>
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

    public string? CustomEmojiStickerSetName { get; init; }

    public long? LinkedChatId { get; init; }

    public ChatLocation? Location { get; init; }

    public UserRating? Rating { get; init; }

    public Audio? FirstProfileAudio { get; init; }

    public UniqueGiftColors? UniqueGiftColors { get; init; }

    public int? PaidMessageStarCount { get; init; }

    public User? GuardBot { get; init; }

    public Community? Community { get; init; }
}
