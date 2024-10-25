using System.Collections.Generic;

namespace Telegram.BotAPI.Types;

// https://core.telegram.org/bots/api#userchatboosts
public sealed class UserChatBoosts
{
    public List<ChatBoost> Boosts { get; set; }
}
