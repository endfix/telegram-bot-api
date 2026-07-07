namespace Telegram.BotAPI.Types;

public sealed class InputRichMessage
{
    public string? Html { get; init; }

    public string? Markdown { get; init; }

    public bool? IsRtl { get; init; }

    public bool? SkipEntityDetection { get; init; }
}
