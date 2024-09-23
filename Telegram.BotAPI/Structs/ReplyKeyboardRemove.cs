namespace Telegram.BotAPI.Structs
{
    // https://core.telegram.org/bots/api#replykeyboardremove
    public class ReplyKeyboardRemove : ReplyMarkupType
    {
        public bool RemoveKeyboard { get; set; }

        public bool Selective { get; set; }
    }
}
