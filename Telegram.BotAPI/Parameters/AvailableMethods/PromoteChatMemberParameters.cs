namespace Telegram.BotAPI.Parameters;

public sealed class PromoteChatMemberParameters : ApiRequestParameters
{
    public required object ChatId { get; set; }

    public required long UserId { get; set; }

    public bool? IsAnonymous { get; set; }

    public bool? CanManageChat { get; set; }

    public bool? CanDeleteMessages { get; set; }

    public bool? CanManageVideoChats { get; set; }

    public bool? CanRestrictMembers { get; set; }

    public bool? CanPromoteMembers { get; set; }

    public bool? CanChangeInfo { get; set; }

    public bool? CanInviteUsers { get; set; }

    public bool? CanPostStories { get; set; }

    public bool? CanEditStories { get; set; }

    public bool? CanDeleteStories { get; set; }

    public bool? CanPostMessages { get; set; }

    public bool? CanEditMessages { get; set; }

    public bool? CanPinMessages { get; set; }

    public bool? CanManageTopics { get; set; }

    public bool? CanManageDirectMessages { get; set; }

    public bool? CanManageTags { get; set; }
}
