namespace Telegram.BotAPI.Types;

public sealed class BusinessBotRights
{
    public bool CanReply { get; set; }

    public bool CanReadMessages { get; set; }

    public bool CanDeleteSentMessages { get; set; }

    public bool CanDeleteAllMessages { get; set; }

    public bool CanEditName { get; set; }

    public bool CanEditBio { get; set; }

    public bool CanEditProfilePhoto { get; set; }

    public bool CanEditUsername { get; set; }

    public bool CanChangeGiftSettings { get; set; }

    public bool CanViewGiftsAndStars { get; set; }

    public bool CanConvertGiftsToStars { get; set; }

    public bool CanTransferAndUpgradeGifts { get; set; }

    public bool CanTransferStars { get; set; }

    public bool CanManageStories { get; set; }
}
