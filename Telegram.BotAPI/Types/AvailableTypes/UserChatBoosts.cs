using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

public sealed class UserChatBoosts
{
    public required IReadOnlyList<ChatBoost> Boosts { get; init; }
}
