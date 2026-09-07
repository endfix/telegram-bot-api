using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Base type for a partner involved in a Telegram Stars transaction.</summary>
public abstract class TransactionPartner
{
    /// <summary>Gets the transaction partner type.</summary>
    public abstract TransactionPartnerType Type { get; }
}

/// <summary>Describes a transaction partner that is a user.</summary>
public sealed class TransactionPartnerUser : TransactionPartner
{
    /// <inheritdoc/>
    public override TransactionPartnerType Type => TransactionPartnerType.User;

    /// <summary>Type of the transaction.</summary>
    public required TransactionType TransactionType { get; init; }

    /// <summary>The user involved in the transaction.</summary>
    public required User User { get; init; }

    /// <summary>Optional. Affiliate information associated with the transaction.</summary>
    public AffiliateInfo? Affiliate { get; init; }

    /// <summary>Optional. Bot-defined invoice payload.</summary>
    public string? InvoicePayload { get; init; }

    /// <summary>Optional. Subscription period in seconds.</summary>
    public int? SubscriptionPeriod { get; init; }

    /// <summary>Optional. Paid media purchased in the transaction.</summary>
    public IReadOnlyList<PaidMedia>? PaidMedia { get; init; }

    /// <summary>Optional. Bot-defined payload for the purchased paid media.</summary>
    public string? PaidMediaPayload { get; init; }

    /// <summary>Optional. Gift involved in the transaction.</summary>
    public Gift? Gift { get; init; }

    /// <summary>Optional. Number of months of the Telegram Premium subscription.</summary>
    public int? PremiumSubscriptionDuration { get; init; }
}

/// <summary>Describes a transaction partner that is a chat.</summary>
public sealed class TransactionPartnerChat : TransactionPartner
{
    /// <inheritdoc/>
    public override TransactionPartnerType Type => TransactionPartnerType.Chat;

    /// <summary>The chat involved in the transaction.</summary>
    public required Chat Chat { get; init; }

    /// <summary>Optional. Gift involved in the transaction.</summary>
    public Gift? Gift { get; init; }
}

/// <summary>Describes an affiliate program as a transaction partner.</summary>
public sealed class TransactionPartnerAffiliateProgram : TransactionPartner
{
    /// <inheritdoc/>
    public override TransactionPartnerType Type => TransactionPartnerType.AffiliateProgram;

    /// <summary>Optional. The sponsor user of the affiliate program.</summary>
    public User? SponsorUser { get; init; }

    /// <summary>Number of Telegram Stars received by the affiliate for each 1000 Telegram Stars received by the bot from referred users.</summary>
    public required int CommissionPerMille { get; init; }
}

/// <summary>Describes Fragment as a transaction partner.</summary>
public sealed class TransactionPartnerFragment : TransactionPartner
{
    /// <inheritdoc/>
    public override TransactionPartnerType Type => TransactionPartnerType.Fragment;

    /// <summary>Optional. Current state of the revenue withdrawal.</summary>
    public RevenueWithdrawalState? WithdrawalState { get; init; }
}

/// <summary>Describes Telegram Ads as a transaction partner.</summary>
public sealed class TransactionPartnerTelegramAds : TransactionPartner
{
    /// <inheritdoc/>
    public override TransactionPartnerType Type => TransactionPartnerType.TelegramAds;
}

/// <summary>Describes the Telegram API as a transaction partner.</summary>
public sealed class TransactionPartnerTelegramApi : TransactionPartner
{
    /// <inheritdoc/>
    public override TransactionPartnerType Type => TransactionPartnerType.TelegramApi;

    /// <summary>Number of API requests made.</summary>
    public required int RequestCount { get; init; }
}

/// <summary>Describes an unknown or other transaction partner.</summary>
public sealed class TransactionPartnerOther : TransactionPartner
{
    /// <inheritdoc/>
    public override TransactionPartnerType Type => TransactionPartnerType.Other;
}
