namespace Telegram.BotAPI.Types
{
    // https://core.telegram.org/bots/api#replykeyboardremove
    public class ReplyKeyboardRemove : ReplyMarkup
    {
        public bool RemoveKeyboard { get; set; }

        public bool Selective { get; set; }
    }
}
