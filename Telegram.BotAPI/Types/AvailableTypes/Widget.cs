namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Describes an HTML widget.</summary>
public sealed class Widget
{
    /// <summary>
    /// Unique identifier of the shared widget, which can be used to send the widget again with
    /// <c>sendSharedWidget</c>; omitted if the widget is not shared.
    /// </summary>
    public string? Id { get; init; }

    /// <summary>
    /// Width of the widget in logical pixels; omitted if the widget occupies the full width of
    /// the message bubble.
    /// </summary>
    public int? Width { get; init; }

    /// <summary>
    /// Height of the widget in logical pixels; omitted if the height of the widget is not fixed.
    /// </summary>
    public int? Height { get; init; }

    /// <summary>HTML code of the widget.</summary>
    public required string Html { get; init; }

    /// <summary>
    /// Public data of the widget, which is available wherever the widget is shown. Messages with
    /// the same shared widget use the same public data.
    /// </summary>
    public string? PublicData { get; init; }

    /// <summary>Data of the widget that is specific to the message.</summary>
    public string? ChatData { get; init; }
}
