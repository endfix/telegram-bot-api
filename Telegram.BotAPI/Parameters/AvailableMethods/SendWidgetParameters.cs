using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Enums;
using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>sendWidget</c> method.
/// </summary>
public sealed class SendWidgetParameters : ApiRequestParameters
{
    /// <summary>
    /// Target chat or username of the target supergroup in the format <c>@username</c>.
    /// </summary>
    public required ChatIdSource ChatId { get; init; }

    /// <summary>Target message thread.</summary>
    public long? MessageThreadId { get; init; }

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
    /// Whether to create a shared widget that can be sent again with <c>sendSharedWidget</c>.
    /// </summary>
    public bool? IsShared { get; init; }

    /// <summary>Sends the message silently when <see langword="true"/>.</summary>
    public bool? DisableNotification { get; init; }

    /// <summary>
    /// Protects the message from forwarding and saving when <see langword="true"/>.
    /// </summary>
    public bool? ProtectContent { get; init; }

    /// <summary>Allows paid broadcasts using Telegram Stars.</summary>
    public bool? AllowPaidBroadcast { get; init; }

    /// <summary>Unique identifier of a message effect.</summary>
    public string? MessageEffectId { get; init; }

    /// <summary>Description of the message to reply to.</summary>
    public ReplyParameters? ReplyParameters { get; init; }

    /// <summary>Inline or reply keyboard attached to the message.</summary>
    public ReplyMarkup? ReplyMarkup { get; init; }
}
