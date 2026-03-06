namespace Telegram.BotAPI.Parameters;

public class GetBusinessAccountGiftsParameters : ApiRequestParameters
{
    public required string BusinessConnectionId { get; init; }

    public bool? ExcludeUnsaved { get; init; }

    public bool? ExcludeSaved { get; init; }

    public bool? ExcludeUnlimited { get; init; }

    public bool? ExcludeLimitedUpgradable { get; init; }

    public bool? ExcludeLimitedNonUpgradable { get; init; }

    public bool? ExcludeUnique { get; init; }

    public bool? ExcludeFromBlockchain { get; init; }

    public bool? SortByPrice { get; init; }

    public string? Offset { get; init; }

    public int? Limit { get; init; }
}
