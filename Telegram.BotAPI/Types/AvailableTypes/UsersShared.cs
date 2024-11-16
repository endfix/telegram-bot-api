using System.Collections.Generic;

namespace Telegram.BotAPI.Types.AvailableTypes;

public sealed class UsersShared
{
    public int RequestId { get; set; }

    public List<SharedUser> Users { get; set; }
}
