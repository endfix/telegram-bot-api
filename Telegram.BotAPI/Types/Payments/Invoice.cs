namespace Telegram.BotAPI.Types.Payments;

// https://core.telegram.org/bots/api#invoice
public sealed class Invoice
{
    public string Title { get; set; }

    public string Description { get; set; }

    public string StartParameter { get; set; }

    public string Currency { get; set; }

    public int TotalAmount { get; set; }
}
