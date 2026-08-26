using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

public sealed class CreateChatInviteLinkParameters : ApiRequestParameters
{
    public required ChatIdSource ChatId { get; init; }

    public string? Name { get; init; }

    public int? ExpireDate { get; init; }

    public int? MemberLimit { get; init; }

    public bool? CreatesJoinRequest { get; init; }
}
