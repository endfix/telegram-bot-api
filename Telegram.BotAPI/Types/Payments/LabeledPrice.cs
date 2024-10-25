namespace Telegram.BotAPI.Types.Payments;

// https://core.telegram.org/bots/api#labeledprice
public sealed class LabeledPrice
{
    public string Label { get; set; }

    public int Amount { get; set; }
}
