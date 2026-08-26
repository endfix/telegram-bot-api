namespace Endfix.Telegram.BotAPI.Types;

public sealed class LinkPreviewOptions
{
    public bool? IsDisabled { get; init; }

    public string? Url { get; init; }

    public bool? PreferSmallMedia { get; init; }

    public bool? PreferLargeMedia { get; init; }

    public bool? ShowAboveText { get; init; }
}
