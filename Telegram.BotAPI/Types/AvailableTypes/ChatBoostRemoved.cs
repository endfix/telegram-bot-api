namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Represents a boost removed from a chat.</summary>
public sealed class ChatBoostRemoved
{
    /// <summary>Chat from which the boost was removed.</summary>
    public required Chat Chat { get; init; }

    /// <summary>Unique identifier of the removed boost.</summary>
    public required string BoostId { get; init; }

    /// <summary>Date when the boost was removed, in Unix time.</summary>
    public required int RemoveDate { get; init; }

    /// <summary>Source of the removed boost.</summary>
    public required ChatBoostSource Source { get; init; }
}
