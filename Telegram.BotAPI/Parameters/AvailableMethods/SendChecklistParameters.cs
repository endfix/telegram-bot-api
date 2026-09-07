using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>sendChecklist</c> method.
/// </summary>
public sealed class SendChecklistParameters : ApiRequestParameters
{
    /// <summary>Identifier of the business connection on whose behalf the message is sent.</summary>
    public required string BusinessConnectionId { get; init; }

    /// <summary>Target chat identifier.</summary>
    public required long ChatId { get; init; }

    /// <summary>Checklist to send.</summary>
    public required InputChecklist Checklist { get; init; }

    /// <summary>Whether to send the message silently.</summary>
    public bool? DisableNotification { get; init; }

    /// <summary>Whether to protect the message from forwarding and saving.</summary>
    public bool? ProtectContent { get; init; }

    /// <summary>Message effect identifier.</summary>
    public string? MessageEffectId { get; init; }

    /// <summary>Description of the message to reply to.</summary>
    public ReplyParameters? ReplyParameters { get; init; }

    /// <summary>Inline keyboard for the message.</summary>
    public InlineKeyboardMarkup? ReplyMarkup { get; init; }
}
