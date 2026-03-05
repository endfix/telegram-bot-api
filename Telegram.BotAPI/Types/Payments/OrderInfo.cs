namespace Telegram.BotAPI.Types;

public sealed class OrderInfo
{
    public string? Name { get; init; }

    public string? PhoneNumber { get; init; }

    public string? Email { get; init; }

    public ShippingAddress? ShippingAddress { get; init; }
}
