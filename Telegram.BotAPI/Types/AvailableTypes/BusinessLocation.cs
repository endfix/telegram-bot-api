namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Contains information about the business location.</summary>
public sealed class BusinessLocation
{
    /// <summary>Address of the business.</summary>
    public required string Address { get; init; }

    /// <summary>Optional. Geographic location of the business.</summary>
    public Location? Location { get; init; }
}
