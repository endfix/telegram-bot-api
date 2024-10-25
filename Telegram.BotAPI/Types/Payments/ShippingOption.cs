using System.Collections.Generic;

namespace Telegram.BotAPI.Types.Payments;

// https://core.telegram.org/bots/api#shippingoption
public sealed class ShippingOption
{
    public string Id { get; set; }

    public string Title { get; set; }

    public List<LabeledPrice> Prices { get; set; }
}
