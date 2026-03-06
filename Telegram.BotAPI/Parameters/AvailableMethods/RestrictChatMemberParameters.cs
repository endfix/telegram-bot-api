using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class RestrictChatMemberParameters : ApiRequestParameters
{
    public required object ChatId { get; init; }

    public required long UserId { get; init; }

    public required ChatPermissions Permissions { get; init; }

    public bool? UseIndependentChatPermissions { get; init; }

    public int? UntilDate { get; init; }
}
