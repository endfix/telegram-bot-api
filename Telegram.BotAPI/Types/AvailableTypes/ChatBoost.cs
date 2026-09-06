namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Describes a boost added to a chat.</summary>
public sealed class ChatBoost
{
    /// <summary>Unique identifier of the boost.</summary>
    public required string BoostId { get; init; }

    /// <summary>Date when the boost was added, in Unix time.</summary>
    public required int AddDate { get; init; }

    /// <summary>Date when the boost will expire, in Unix time.</summary>
    public required int ExpirationDate { get; init; }

    /// <summary>Source of the boost.</summary>
    public required ChatBoostSource Source { get; init; }
}
