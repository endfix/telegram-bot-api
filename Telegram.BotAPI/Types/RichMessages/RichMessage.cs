using System.Collections.Generic;

namespace Telegram.BotAPI.Types;

public sealed class RichMessage
{
    public required IReadOnlyList<RichBlock> Blocks { get; init; }

    public bool? IsRtl { get; init; }
}
