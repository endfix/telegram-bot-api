using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

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
