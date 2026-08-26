using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

public sealed class RestrictChatMemberParameters : ApiRequestParameters
{
    public required ChatIdSource ChatId { get; init; }

    public required long UserId { get; init; }

    public required ChatPermissions Permissions { get; init; }

    public bool? UseIndependentChatPermissions { get; init; }

    public int? UntilDate { get; init; }
}
