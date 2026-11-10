using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Describes widget message content for an inline result.</summary>
/// <remarks>
/// Currently, widgets can't be sent in response to inline queries in the production environment.
/// </remarks>
public sealed class InputWidgetMessageContent : InputMessageContent
{
    /// <summary>
    /// HTML code of the widget, from 1 through 32768 bytes; at most 4096 bytes when compressed by
    /// zlib at the maximum compression level.
    /// </summary>
    public required string Html { get; init; }

    /// <summary>
    /// Width of the widget in logical pixels; omit it to use the full width of the message bubble.
    /// The app clamps the width to the range from 200 through the maximum bubble width.
    /// </summary>
    public int? Width { get; init; }

    /// <summary>
    /// Height of the widget in logical pixels; omit it if the height is not fixed. The app clamps
    /// the height to the range from 50 through 600.
    /// </summary>
    public int? Height { get; init; }

    /// <summary>
    /// Public data of the widget, from 0 through 1024 bytes, which is available wherever the
    /// widget is shown. Messages with the same shared widget use the same public data.
    /// </summary>
    public string? PublicData { get; init; }

    /// <summary>
    /// Data of the widget that is specific to the message, from 0 through 1024 bytes.
    /// </summary>
    public string? ChatData { get; init; }

    /// <summary>Widget caption, from 0 through 1024 characters after entity parsing.</summary>
    public string? Caption { get; init; }

    /// <summary>Mode for parsing entities in the widget caption.</summary>
    public ParseMode? ParseMode { get; init; }

    /// <summary>Explicit entities in the widget caption.</summary>
    public IReadOnlyList<MessageEntity>? CaptionEntities { get; init; }

    /// <summary>Whether to show the caption above the widget.</summary>
    public bool? ShowCaptionAboveMedia { get; init; }

    /// <summary>Whether to allow the widget to send queries to the bot.</summary>
    public bool? AllowQueries { get; init; }

    /// <summary>
    /// Whether to create a shared widget. Each message sent from the result creates a separate
    /// shared widget whose identifier is received only in the <c>widget_id</c> field of queries
    /// from the widget. To send an existing shared widget in response to an inline query, use
    /// <see cref="InputSharedWidgetMessageContent"/> instead.
    /// </summary>
    public bool? IsShared { get; init; }
}
