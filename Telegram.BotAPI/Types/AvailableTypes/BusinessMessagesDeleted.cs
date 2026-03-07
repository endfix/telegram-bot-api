using System.Collections.Generic;

namespace Telegram.BotAPI.Types;

public sealed class BusinessMessagesDeleted
{
    public required string BusinessConnectionId { get; init; }

    public required Chat Chat { get; init; }

    public required IReadOnlyList<int> MessageIds { get; init; }
}
