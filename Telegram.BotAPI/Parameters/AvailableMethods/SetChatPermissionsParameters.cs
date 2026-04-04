using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class SetChatPermissionsParameters : ApiRequestParameters
{
    public required ChatIdSource ChatId { get; init; }

    public required ChatPermissions Permissions { get; init; }

    public bool? UseIndependentChatPermissions { get; init; }
}
