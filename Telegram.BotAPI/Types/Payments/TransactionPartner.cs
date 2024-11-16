using System.Collections.Generic;
using Telegram.BotAPI.Types.AvailableTypes;

namespace Telegram.BotAPI.Types.Payments;

/// <summary>
/// This object describes the source of a transaction, or its recipient for outgoing transactions. Currently, it can be one of
/// <see cref="TransactionPartnerUser">TransactionPartnerUser<\see> or
/// <see cref="TransactionPartnerFragment">TransactionPartnerFragment<\see> or
/// <see cref="TransactionPartnerTelegramAds">TransactionPartnerTelegramAds<\see> or
/// <see cref="TransactionPartnerTelegramApi">TransactionPartnerTelegramApi<\see> or
/// <see cref="TransactionPartnerOther">TransactionPartnerOther<\see>
/// </summary>
public abstract class TransactionPartner
{
    public abstract string Type { get; }

    public static class Types
    {
        public const string USER = "user";

        public const string FRAGMENT = "fragment";

        public const string TELEGRAM_ADS = "telegram_ads";

        public const string TELEGRAM_API = "telegram_api";

        public const string OTHER = "other";
    }
}

/// <summary>
/// Describes a transaction with a user.
/// </summary>
public sealed class TransactionPartnerUser : TransactionPartner
{
    /// <summary>
    /// Type of the transaction partner, always “user”
    /// </summary>
    public override string Type => Types.USER;

    /// <summary>
    /// Information about the user
    /// </summary>
    public User User { get; set; }

    /// <summary>
    /// Optional. Bot-specified invoice payload
    /// </summary>
    public string InvoicePayload { get; set; }

    /// <summary>
    /// Optional. Information about the paid media bought by the user
    /// </summary>
    public List<PaidMedia> PaidMedia { get; set; }

    /// <summary>
    /// Optional. Bot-specified paid media payload
    /// </summary>
    public string PaidMediaPayload { get; set; }
}

/// <summary>
/// Describes a withdrawal transaction with Fragment.
/// </summary>
public sealed class TransactionPartnerFragment : TransactionPartner
{
    /// <summary>
    /// Type of the transaction partner, always “fragment”
    /// </summary>
    public override string Type => Types.FRAGMENT;

    /// <summary>
    /// Optional. State of the transaction if the transaction is outgoing
    /// </summary>
    public RevenueWithdrawalState WithdrawalState { get; set; }
}

/// <summary>
/// Describes a withdrawal transaction to the Telegram Ads platform.
/// </summary>
public sealed class TransactionPartnerTelegramAds : TransactionPartner
{
    /// <summary>
    /// Type of the transaction partner, always “telegram_ads”
    /// </summary>
    public override string Type => Types.TELEGRAM_ADS;
}

/// <summary>
/// Describes a transaction with payment for <see href="https://core.telegram.org/bots/api#paid-broadcasts">paid broadcasting</see>.
/// </summary>
public sealed class TransactionPartnerTelegramApi : TransactionPartner
{
    /// <summary>
    /// Type of the transaction partner, always “telegram_api”
    /// </summary>
    public override string Type => Types.TELEGRAM_API;

    /// <summary>
    /// The number of successful requests that exceeded regular limits and were therefore billed
    /// </summary>
    public int RequestCount { get; set; }
}

/// <summary>
/// Describes a transaction with an unknown source or recipient.
/// </summary>
public sealed class TransactionPartnerOther : TransactionPartner
{
    /// <summary>
    /// Type of the transaction partner, always “other”
    /// </summary>
    public override string Type => Types.OTHER;
}
