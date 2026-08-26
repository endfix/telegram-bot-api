namespace Endfix.Telegram.BotAPI.Types;

public sealed class AffiliateInfo
{
    public User? AffiliateUser { get; init; }

    public User? AffiliateChat { get; init; }

    public required int CommissionPerMille { get; init; }

    public required int Amount { get; init; }

    public int? NanostarAmount { get; init; }
}
