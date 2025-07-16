namespace Telegram.BotAPI.Types;

public sealed class InlineKeyboardMarkup : ReplyMarkup
{
    public InlineKeyboardButton[][] InlineKeyboard { get; set; }
}
