using System.Collections.Generic;

namespace Telegram.BotAPI.Types.AvailableTypes;

public sealed class UserChatBoosts
{
    public List<ChatBoost> Boosts { get; set; }
}
