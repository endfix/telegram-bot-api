namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Contains information about an order.</summary>
public sealed class OrderInfo
{
    /// <summary> User's full name, if supplied.</summary>
    public string? Name { get; init; }

    /// <summary>User's phone number, if supplied.</summary>
    public string? PhoneNumber { get; init; }

    /// <summary>User's email address, if supplied.</summary>
    public string? Email { get; init; }

    /// <summary>User's shipping address, if supplied.</summary>
    public ShippingAddress? ShippingAddress { get; init; }
}
