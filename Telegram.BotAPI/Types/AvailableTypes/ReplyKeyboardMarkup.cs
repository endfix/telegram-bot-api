namespace Telegram.BotAPI.Types;

public sealed class ReplyKeyboardMarkup : ReplyMarkup
{
    public KeyboardButton[][] Keyboard { get; set; }

    public bool IsPersistent { get; set; }

    public bool ResizeKeyboard { get; set; }

    public bool OneTimeKeyboard { get; set; }

    public string InputFieldPlaceholder { get; set; }

    public bool Selective { get; set; }
}
