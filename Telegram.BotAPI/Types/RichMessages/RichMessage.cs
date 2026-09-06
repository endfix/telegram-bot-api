using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Describes a rich formatted message received from Telegram.</summary>
public sealed class RichMessage
{
    /// <summary>Content of the message as a list of rich blocks.</summary>
    public required IReadOnlyList<RichBlock> Blocks { get; init; }

    /// <summary>Optional. Indicates whether the rich message must be shown right-to-left.</summary>
    public bool? IsRtl { get; init; }
}
