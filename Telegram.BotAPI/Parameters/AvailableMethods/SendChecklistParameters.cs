using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class SendChecklistParameters : ApiRequestParameters
{
    public required string BusinessConnectionId { get; init; }

    public required long ChatId { get; init; }

    public required InputChecklist Checklist { get; init; }

    public bool? DisableNotification { get; init; }

    public bool? ProtectContent { get; init; }

    public string? MessageEffectId { get; init; }

    public ReplyParameters? ReplyParameters { get; init; }

    public InlineKeyboardMarkup? ReplyMarkup { get; init; }
}
