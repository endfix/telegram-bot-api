using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

public sealed class GetUserGiftsParameters : ApiRequestParameters
{
    public required long UserId { get; init; }

    public bool? ExcludeUnlimited { get; init; }

    public bool? ExcludeLimitedUpgradable { get; init; }

    public bool? ExcludeLimitedNonUpgradable { get; init; }

    public bool? ExcludeFromBlockchain { get; init; }

    public bool? ExcludeUnique { get; init; }

    public bool? SortByPrice { get; init; }

    public string? Offset { get; init; }

    public int? Limit { get; init; }
}
