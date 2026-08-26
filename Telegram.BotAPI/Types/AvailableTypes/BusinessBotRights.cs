namespace Endfix.Telegram.BotAPI.Types;

public sealed class BusinessBotRights
{
    public bool? CanReply { get; init; }

    public bool? CanReadMessages { get; init; }

    public bool? CanDeleteSentMessages { get; init; }

    public bool? CanDeleteAllMessages { get; init; }

    public bool? CanEditName { get; init; }

    public bool? CanEditBio { get; init; }

    public bool? CanEditProfilePhoto { get; init; }

    public bool? CanEditUsername { get; init; }

    public bool? CanChangeGiftSettings { get; init; }

    public bool? CanViewGiftsAndStars { get; init; }

    public bool? CanConvertGiftsToStars { get; init; }

    public bool? CanTransferAndUpgradeGifts { get; init; }

    public bool? CanTransferStars { get; init; }

    public bool? CanManageStories { get; init; }
}
