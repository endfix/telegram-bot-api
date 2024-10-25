using System.Collections.Generic;

namespace Telegram.BotAPI.Types;

// https://core.telegram.org/bots/api#businessmessagesdeleted
public sealed class BusinessMessagesDeleted
{
    public string BusinessConnectionId { get; set; }

    public Chat Chat { get; set; }

    public List<int> MessageIds { get; set; }
}
