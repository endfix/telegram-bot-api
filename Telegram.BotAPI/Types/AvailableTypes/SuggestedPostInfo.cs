using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Contains information about a suggested post.</summary>
public sealed class SuggestedPostInfo
{
    /// <summary>Current state of the suggested post.</summary>
    public SuggestedPostInfoState State { get; init; }

    /// <summary>Price associated with the suggested post, if available.</summary>
    public SuggestedPostPrice? Price { get; init; }

    /// <summary>Scheduled send date in Unix time, if available.</summary>
    public int? SendDate { get; init; }
}
