using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

public sealed class PromoteChatMemberParameters : ApiRequestParameters
{
    public required ChatIdSource ChatId { get; init; }

    public required long UserId { get; init; }

    public bool? IsAnonymous { get; init; }

    public bool? CanManageChat { get; init; }

    public bool? CanDeleteMessages { get; init; }

    public bool? CanManageVideoChats { get; init; }

    public bool? CanRestrictMembers { get; init; }

    public bool? CanPromoteMembers { get; init; }

    public bool? CanChangeInfo { get; init; }

    public bool? CanInviteUsers { get; init; }

    public bool? CanPostStories { get; init; }

    public bool? CanEditStories { get; init; }

    public bool? CanDeleteStories { get; init; }

    public bool? CanPostMessages { get; init; }

    public bool? CanEditMessages { get; init; }

    public bool? CanPinMessages { get; init; }

    public bool? CanManageTopics { get; init; }

    public bool? CanManageDirectMessages { get; init; }

    public bool? CanManageTags { get; init; }

    public bool? CanSendWelcomeMessages { get; init; }
}
