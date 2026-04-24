using Telegram.BotAPI.Protocol;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class CreateChatInviteLinkParameters : ApiRequestParameters
{
    public required ChatIdSource ChatId { get; init; }

    public string? Name { get; init; }

    public int? ExpireDate { get; init; }

    public int? MemberLimit { get; init; }

    public bool? CreatesJoinRequest { get; init; }
}
