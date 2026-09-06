using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Contains gifts received and owned by a user or a chat.</summary>
public sealed class OwnedGifts
{
    /// <summary>Total number of gifts owned by the user or chat.</summary>
    public required int TotalCount { get; init; }

    /// <summary>List of owned gifts.</summary>
    public required IReadOnlyList<OwnedGift> Gifts { get; init; }

    /// <summary>Optional. Offset for the next request; empty if there are no more results.</summary>
    public string? NextOffset { get; init; }
}
