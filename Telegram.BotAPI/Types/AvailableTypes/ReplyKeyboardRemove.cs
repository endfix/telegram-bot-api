namespace Telegram.BotAPI.Types.AvailableTypes;

public sealed class ReplyKeyboardRemove : ReplyMarkup
{
    public bool RemoveKeyboard { get; set; }

    public bool Selective { get; set; }
}
