namespace Endfix.Telegram.BotAPI.Types;

public sealed class ReplyKeyboardRemove : ReplyMarkup
{
    public required bool RemoveKeyboard { get; init; }

    public bool? Selective { get; init; }
}
