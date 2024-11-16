using System.Collections.Generic;

namespace Telegram.BotAPI.Types.AvailableTypes;

public sealed class BusinessMessagesDeleted
{
    public string BusinessConnectionId { get; set; }

    public Chat Chat { get; set; }

    public List<int> MessageIds { get; set; }
}
