using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class EditMessageChecklistParameters : ApiRequestParameters
{
    public string BusinessConnectionId { get; set; }

    public long ChatId { get; set; }

    public int MessageId { get; set; }

    public InputChecklist Checklist { get; set; }

    public InlineKeyboardMarkup ReplyMarkup { get; set; }
}
