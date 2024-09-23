namespace Telegram.BotAPI.Structs
{
    // https://core.telegram.org/bots/api#replykeyboardmarkup
    public class ReplyKeyboardMarkup : ReplyMarkupType
    {
        public List<List<KeyboardButton>> Keyboard { get; set; } = new List<List<KeyboardButton>>();

        public bool IsPersistent { get; set; }

        public bool ResizeKeyboard { get; set; }

        public bool OneTimeKeyboard { get; set; }

        public string InputFieldPlaceholder { get; set; } = string.Empty;

        public bool Selective { get; set; }

        public void AddRow(KeyboardButton button)
        {
            Keyboard.Add(new List<KeyboardButton>
            {
                button
            });
        }

        public void AddCell(KeyboardButton button)
        {
            if (!Keyboard.Any())
            {
                throw new Exception("Need to add row!");
            }

            Keyboard.Last().Add(button);
        }
    }
}
