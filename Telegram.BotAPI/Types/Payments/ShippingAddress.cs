namespace Telegram.BotAPI.Types;

public sealed class ShippingAddress
{
    public required string CountryCode { get; init; }

    public required string State { get; init; }

    public required string City { get; init; }

    public required string StreetLine1 { get; init; }

    public required string StreetLine2 { get; init; }

    public required string PostCode { get; init; }
}
