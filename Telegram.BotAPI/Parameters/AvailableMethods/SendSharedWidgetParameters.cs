using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Enums;
using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>sendSharedWidget</c> method.
/// </summary>
public sealed class SendSharedWidgetParameters : ApiRequestParameters
{
    /// <summary>
    /// Target chat or username of the target supergroup in the format <c>@username</c>.
    /// </summary>
    public required ChatIdSource ChatId { get; init; }

    /// <summary>Target message thread.</summary>
    public long? MessageThreadId { get; init; }

    /// <summary>Unique identifier of the shared widget.</summary>
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
