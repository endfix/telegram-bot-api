using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Represents a list of boosts added to a chat by a user.
/// </summary>
public sealed class UserChatBoosts
{
    /// <summary>The list of boosts added to the chat by the user.</summary>
    public required IReadOnlyList<ChatBoost> Boosts { get; init; }
}
