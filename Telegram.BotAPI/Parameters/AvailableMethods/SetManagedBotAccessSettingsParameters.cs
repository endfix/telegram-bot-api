using System.Collections.Generic;
using Telegram.BotAPI.Protocol;

namespace Telegram.BotAPI.Parameters;

public sealed class SetManagedBotAccessSettingsParameters : ApiRequestParameters
{
    public required long UserId { get; init; }

    public required bool IsAccessRestricted { get; init; }

    public IReadOnlyList<long>? AddedUserIds { get; init; }
}
