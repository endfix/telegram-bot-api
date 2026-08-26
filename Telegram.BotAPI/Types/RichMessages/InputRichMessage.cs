using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

public sealed class InputRichMessage
{
    public IReadOnlyList<InputRichBlock>? Blocks { get; init; }

    public string? Html { get; init; }

    public string? Markdown { get; init; }

    public bool? IsRtl { get; init; }

    public IReadOnlyList<InputRichMessageMedia>? Media { get; init; }

    public bool? SkipEntityDetection { get; init; }
}
