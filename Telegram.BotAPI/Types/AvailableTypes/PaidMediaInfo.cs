using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Describes paid media added to a message.</summary>
public sealed class PaidMediaInfo
{
    /// <summary>Number of Telegram Stars required to buy access to the media.</summary>
    public required int StarCount { get; init; }

    /// <summary>Information about the paid media.</summary>
    public required IReadOnlyList<PaidMedia> PaidMedia { get; init; }
}
