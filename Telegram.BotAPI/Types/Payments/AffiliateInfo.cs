namespace Telegram.BotAPI.Types;

public sealed class AffiliateInfo
{
    public User AffiliateUser { get; set; }

    public User AffiliateChat { get; set; }

    public int CommissionPerMille { get; set; }

    public int Amount { get; set; }

    public int NanostarAmount { get; set; }
}
