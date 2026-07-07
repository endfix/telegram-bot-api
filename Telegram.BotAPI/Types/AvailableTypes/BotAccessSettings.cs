using System.Collections.Generic;

namespace Telegram.BotAPI.Types;

public sealed class BotAccessSettings
{
    public required bool IsAccessRestricted { get; init; }

    public IReadOnlyList<User>? AddedUsers { get; init; }
}
