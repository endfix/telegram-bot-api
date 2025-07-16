namespace Telegram.BotAPI.Types;

public sealed class ShippingOption
{
    public string Id { get; set; }

    public string Title { get; set; }

    public LabeledPrice[] Prices { get; set; }
}
