using System.Collections.Generic;

namespace Telegram.BotAPI.Types;

public sealed class UsersShared
{
    public required int RequestId { get; init; }

    public required IReadOnlyList<SharedUser> Users { get; init; }
}
