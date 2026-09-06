namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Represents an update about a chat boost.</summary>
public sealed class ChatBoostUpdated
{
    /// <summary>Chat whose boost was updated.</summary>
    public required Chat Chat { get; init; }

    /// <summary>Current boost information.</summary>
    public required ChatBoost Boost { get; init; }
}
