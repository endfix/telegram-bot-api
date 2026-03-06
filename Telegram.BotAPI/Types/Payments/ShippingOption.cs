using System.Collections.Generic;

namespace Telegram.BotAPI.Types;

public sealed class ShippingOption
{
    public required string Id { get; init; }

    public required string Title { get; init; }

    public required IReadOnlyList<LabeledPrice> Prices { get; init; }
}
