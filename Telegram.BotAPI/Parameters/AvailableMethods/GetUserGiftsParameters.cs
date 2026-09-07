using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>getUserGifts</c> method.
/// </summary>
public sealed class GetUserGiftsParameters : ApiRequestParameters
{
    /// <summary>Target user identifier.</summary>
    public required long UserId { get; init; }

    /// <summary>Whether to exclude gifts with an unlimited supply.</summary>
    public bool? ExcludeUnlimited { get; init; }

    /// <summary>Whether to exclude limited gifts that can be upgraded to unique gifts.</summary>
    public bool? ExcludeLimitedUpgradable { get; init; }

    /// <summary>Whether to exclude limited gifts that cannot be upgraded to unique gifts.</summary>
    public bool? ExcludeLimitedNonUpgradable { get; init; }

    /// <summary>Whether to exclude gifts assigned from TON that cannot be resold or transferred in Telegram.</summary>
    public bool? ExcludeFromBlockchain { get; init; }

    /// <summary>Whether to exclude unique gifts.</summary>
    public bool? ExcludeUnique { get; init; }

    /// <summary>Whether to sort by gift price instead of send date before pagination.</summary>
    public bool? SortByPrice { get; init; }

    /// <summary>Offset returned by the previous request; use an empty string for the first page.</summary>
    public string? Offset { get; init; }

    /// <summary>Maximum number of gifts to return, from 1 through 100. Defaults to 100.</summary>
    public int? Limit { get; init; }
}
