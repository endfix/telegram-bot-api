using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Describes shared widget message content for an inline result.</summary>
/// <remarks>
/// Currently, widgets can't be sent in response to inline queries in the production environment.
/// </remarks>
public sealed class InputSharedWidgetMessageContent : InputMessageContent
{
    /// <summary>Unique identifier of the shared widget created by the bot.</summary>
    public required string WidgetId { get; init; }

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
}
