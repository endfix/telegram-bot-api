namespace Telegram.BotAPI.Types;

public sealed class Gift
{
    public required string Id { get; init; }

    public required Sticker Sticker { get; init; }

    public required int StarCount { get; init; }

    public int? UpgradeStarCount { get; init; }

    public bool? IsPremium { get; init; }

    public bool? HasColors { get; init; }

    public int? TotalCount { get; init; }

    public int? RemainingCount { get; init; }

    public int? PersonalTotalCount { get; init; }

    public int? PersonalRemainingCount { get; init; }

    public GiftBackground? Background { get; init; }

    public int? UniqueGiftVariantCount { get; init; }

    public Chat? PublisherChat { get; init; }
}
