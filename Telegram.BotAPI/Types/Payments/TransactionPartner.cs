using System.Collections.Generic;

namespace Telegram.BotAPI.Types.Payments;

// https://core.telegram.org/bots/api#transactionpartner
public abstract class TransactionPartner
{
    public abstract string Type { get; }

    public static class Types
    {
        public const string USER = "user";

        public const string FRAGMENT = "fragment";

        public const string TELEGRAM_ADS = "telegram_ads";

        public const string OTHER = "other";
    }
}

// https://core.telegram.org/bots/api#transactionpartneruser
public sealed class TransactionPartnerUser : TransactionPartner
{
    public override string Type => Types.USER;

    public string Test { get; set; }

    public User User { get; set; }

    public string InvoicePayload { get; set; }

    public List<PaidMedia> PaidMedia { get; set; }

    public string PaidMediaPayload { get; set; }
}

// https://core.telegram.org/bots/api#transactionpartnerfragment
public sealed class TransactionPartnerFragment : TransactionPartner
{
    public override string Type => Types.FRAGMENT;

    public RevenueWithdrawalState WithdrawalState { get; set; }
}

// https://core.telegram.org/bots/api#transactionpartnertelegramads
public sealed class TransactionPartnerTelegramAds : TransactionPartner
{
    public override string Type => Types.TELEGRAM_ADS;
}

// https://core.telegram.org/bots/api#transactionpartnerother
public sealed class TransactionPartnerOther : TransactionPartner
{
    public override string Type => Types.OTHER;
}
