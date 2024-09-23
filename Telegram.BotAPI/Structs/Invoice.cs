namespace Telegram.BotAPI.Structs
{
    // https://core.telegram.org/bots/api#invoice
    public class Invoice
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string StartParameter { get; set; }

        public string Currency { get; set; }

        public int TotalAmount { get; set; }
    }
}
