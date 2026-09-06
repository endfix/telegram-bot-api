namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Describes actions that users are allowed to perform in a chat.</summary>
public sealed class ChatPermissions
{
    /// <summary>Indicates whether users can send text messages.</summary>
    public bool? CanSendMessages { get; init; }

    /// <summary>Indicates whether users can send audios.</summary>
    public bool? CanSendAudios { get; init; }

    /// <summary>Indicates whether users can send documents.</summary>
    public bool? CanSendDocuments { get; init; }

    /// <summary>Indicates whether users can send photos.</summary>
    public bool? CanSendPhotos { get; init; }

    /// <summary>Indicates whether users can send videos.</summary>
    public bool? CanSendVideos { get; init; }

    /// <summary>Indicates whether users can send video notes.</summary>
    public bool? CanSendVideoNotes { get; init; }

    /// <summary>Indicates whether users can send voice notes.</summary>
    public bool? CanSendVoiceNotes { get; init; }

    /// <summary>Indicates whether users can send polls.</summary>
    public bool? CanSendPolls { get; init; }

    /// <summary>Indicates whether users can send other messages, such as stickers, animations, games or inline bots.</summary>
    public bool? CanSendOtherMessages { get; init; }

    /// <summary>Indicates whether users can add web page previews to their messages.</summary>
    public bool? CanAddWebPagePreviews { get; init; }

    /// <summary>Indicates whether users can change reactions to messages.</summary>
    public bool? CanReactToMessages { get; init; }

    /// <summary>Indicates whether users can edit the chat tag.</summary>
    public bool? CanEditTag { get; init; }

    /// <summary>Indicates whether users can change chat information.</summary>
    public bool? CanChangeInfo { get; init; }

    /// <summary>Indicates whether users can invite new users to the chat.</summary>
    public bool? CanInviteUsers { get; init; }

    /// <summary>Indicates whether users can pin messages.</summary>
    public bool? CanPinMessages { get; init; }

    /// <summary>Indicates whether users can manage topics.</summary>
    public bool? CanManageTopics { get; init; }
}
