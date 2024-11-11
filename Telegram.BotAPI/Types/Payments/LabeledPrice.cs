namespace Telegram.BotAPI.Types.Payments;

public sealed class LabeledPrice
{
    public string Label { get; set; }

    public int Amount { get; set; }
}
