namespace Telegram.BotAPI.Types.AvailableTypes;

public sealed class ChatPermissions
{
    public bool CanSendMessages { get; set; }

    public bool CanSendAudios { get; set; }

    public bool CanSendDocuments { get; set; }

    public bool CanSendPhotos { get; set; }

    public bool CanSendVideos { get; set; }

    public bool CanSendVideoNotes { get; set; }

    public bool CanSendVoiceNotes { get; set; }

    public bool CanSendPolls { get; set; }

    public bool CanSendOtherMessages { get; set; }

    public bool CanAddWebPagePreviews { get; set; }

    public bool CanChangeInfo { get; set; }

    public bool CanInviteUsers { get; set; }

    public bool CanPinMessages { get; set; }

    public bool CanManageTopics { get; set; }
}
