using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

public sealed class EditMessageChecklistParameters : ApiRequestParameters
{
    public required string BusinessConnectionId { get; init; }

    public required long ChatId { get; init; }

    public required long MessageId { get; init; }

    public required InputChecklist Checklist { get; init; }

    public InlineKeyboardMarkup? ReplyMarkup { get; init; }
}
