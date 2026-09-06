using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Contains a list of gifts.</summary>
public sealed class GiftsStruct
{
    /// <summary>List of gifts.</summary>
    public required IReadOnlyList<Gift> Gifts { get; init; }
}
