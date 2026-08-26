namespace Endfix.Telegram.BotAPI.Types;

public sealed class LocationAddress
{
    public required string CountryCode { get; init; }

    public string? State { get; init; }

    public string? City { get; init; }

    public string? Street { get; init; }
}
