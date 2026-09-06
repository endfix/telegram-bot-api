using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>editMessageChecklist</c> method.
/// </summary>
public sealed class EditMessageChecklistParameters : ApiRequestParameters
{
    /// <summary>Unique identifier of the business connection.</summary>
    public required string BusinessConnectionId { get; init; }

    /// <summary>Identifier of the business chat.</summary>
    public required long ChatId { get; init; }

    /// <summary>Identifier of the checklist message.</summary>
    public required long MessageId { get; init; }

    /// <summary>Replacement checklist.</summary>
    public required InputChecklist Checklist { get; init; }

    /// <summary>Inline keyboard attached to the message.</summary>
    public InlineKeyboardMarkup? ReplyMarkup { get; init; }
}
