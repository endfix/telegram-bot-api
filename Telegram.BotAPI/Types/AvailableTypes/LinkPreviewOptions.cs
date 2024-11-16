namespace Telegram.BotAPI.Types.AvailableTypes;

public sealed class LinkPreviewOptions
{
    public bool IsDisabled { get; set; }

    public string Url { get; set; }

    public bool PreferSmallMedia { get; set; }

    public bool PreferLargeMedia { get; set; }

    public bool ShowAboveText { get; set; }
}
