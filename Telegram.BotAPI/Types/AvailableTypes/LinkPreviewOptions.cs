namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Describes link preview generation options for a message.</summary>
public sealed class LinkPreviewOptions
{
    /// <summary>Disables link previews when set.</summary>
    public bool? IsDisabled { get; init; }

    /// <summary>URL for which the preview should be generated, if specified.</summary>
    public string? Url { get; init; }

    /// <summary>Requests a smaller media preview.</summary>
    public bool? PreferSmallMedia { get; init; }

    /// <summary>Requests a larger media preview.</summary>
    public bool? PreferLargeMedia { get; init; }

    /// <summary>Requests that the preview be shown above the message text.</summary>
    public bool? ShowAboveText { get; init; }
}
