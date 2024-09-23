namespace Telegram.BotAPI.Structs
{
    // https://core.telegram.org/bots/api#inlinekeyboardmarkup
    public class InlineKeyboardMarkup : ReplyMarkupType
    {
        public List<List<InlineKeyboardButton>> InlineKeyboard { get; set; } = new List<List<InlineKeyboardButton>>();

        public void AddRow(InlineKeyboardButton button)
        {
            InlineKeyboard.Add(new List<InlineKeyboardButton>
            {
                button
            });
        }

        public void AddCell(InlineKeyboardButton button)
        {
            if (!InlineKeyboard.Any())
            {
                throw new Exception("Need to add row!");
            }

            InlineKeyboard.Last().Add(button);
        }
    }
}
