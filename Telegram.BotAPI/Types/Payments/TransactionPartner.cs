using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

public abstract class TransactionPartner
{
    public abstract TransactionPartnerTypes Type { get; }
}

public sealed class TransactionPartnerUser : TransactionPartner
{
    public override TransactionPartnerTypes Type => TransactionPartnerTypes.User;

    public User User { get; set; }

    public AffiliateInfo Affiliate { get; set; }

    public string InvoicePayload { get; set; }

    public int SubscriptionPeriod { get; set; }

    public PaidMedia[] PaidMedia { get; set; }

    public string PaidMediaPayload { get; set; }

    public string Gift { get; set; }

    public int PremiumSubscriptionDuration { get; set; }
}

public sealed class TransactionPartnerChat : TransactionPartner
{
    public override TransactionPartnerTypes Type => TransactionPartnerTypes.Chat;

    public Chat Chat { get; set; }

    public Gift Gift { get; set; }
}

public sealed class TransactionPartnerAffiliateProgram : TransactionPartner
{
    public override TransactionPartnerTypes Type => TransactionPartnerTypes.AffiliateProgram;

    public User SponsorUser { get; set; }

    public int CommissionPerMille { get; set; }
}

public sealed class TransactionPartnerFragment : TransactionPartner
{
    public override TransactionPartnerTypes Type => TransactionPartnerTypes.Fragment;

    public RevenueWithdrawalState WithdrawalState { get; set; }
}

public sealed class TransactionPartnerTelegramAds : TransactionPartner
{
    public override TransactionPartnerTypes Type => TransactionPartnerTypes.TelegramAds;
}

public sealed class TransactionPartnerTelegramApi : TransactionPartner
{
    public override TransactionPartnerTypes Type => TransactionPartnerTypes.TelegramApi;

    public int RequestCount { get; set; }
}

public sealed class TransactionPartnerOther : TransactionPartner
{
    public override TransactionPartnerTypes Type => TransactionPartnerTypes.Other;
}
