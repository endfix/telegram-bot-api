using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

public sealed class UsersShared
{
    public required int RequestId { get; init; }

    public required IReadOnlyList<SharedUser> Users { get; init; }
}
