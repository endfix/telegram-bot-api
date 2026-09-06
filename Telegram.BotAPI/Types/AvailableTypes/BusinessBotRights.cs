namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Describes rights granted to a business bot.</summary>
public sealed class BusinessBotRights
{
    /// <summary>Indicates whether the bot can reply to messages.</summary>
    public bool? CanReply { get; init; }

    /// <summary>Indicates whether the bot can read messages.</summary>
    public bool? CanReadMessages { get; init; }

    /// <summary>Indicates whether the bot can delete messages sent by itself.</summary>
    public bool? CanDeleteSentMessages { get; init; }

    /// <summary>Indicates whether the bot can delete all messages in the business account.</summary>
    public bool? CanDeleteAllMessages { get; init; }

    /// <summary>Indicates whether the bot can edit the business account name.</summary>
    public bool? CanEditName { get; init; }

    /// <summary>Indicates whether the bot can edit the business account bio.</summary>
    public bool? CanEditBio { get; init; }

    /// <summary>Indicates whether the bot can edit the business account profile photo.</summary>
    public bool? CanEditProfilePhoto { get; init; }

    /// <summary>Indicates whether the bot can edit the business account username.</summary>
    public bool? CanEditUsername { get; init; }

    /// <summary>Indicates whether the bot can change gift settings.</summary>
    public bool? CanChangeGiftSettings { get; init; }

    /// <summary>Indicates whether the bot can view gifts and Telegram Stars.</summary>
    public bool? CanViewGiftsAndStars { get; init; }

    /// <summary>Indicates whether the bot can convert gifts to Telegram Stars.</summary>
    public bool? CanConvertGiftsToStars { get; init; }

    /// <summary>Indicates whether the bot can transfer and upgrade gifts.</summary>
    public bool? CanTransferAndUpgradeGifts { get; init; }

    /// <summary>Indicates whether the bot can transfer Telegram Stars.</summary>
    public bool? CanTransferStars { get; init; }

    /// <summary>Indicates whether the bot can manage stories.</summary>
    public bool? CanManageStories { get; init; }
}
