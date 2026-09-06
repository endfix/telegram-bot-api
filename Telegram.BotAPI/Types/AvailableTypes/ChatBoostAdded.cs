namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Describes boosts added to a chat by a user.</summary>
public sealed class ChatBoostAdded
{
    /// <summary>Number of boosts added to the chat.</summary>
    public required int BoostCount { get; init; }
}
