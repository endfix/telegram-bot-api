using System.Collections.Generic;
using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

public abstract class TransactionPartner
{
    public abstract TransactionPartnerType Type { get; }
}

public sealed class TransactionPartnerUser : TransactionPartner
{
    public override TransactionPartnerType Type => TransactionPartnerType.User;

    public required TransactionType TransactionType { get; init; }

    public required User User { get; init; }

    public AffiliateInfo? Affiliate { get; init; }

    public string? InvoicePayload { get; init; }

    public int? SubscriptionPeriod { get; init; }

    public IReadOnlyList<PaidMedia>? PaidMedia { get; init; }

    public string? PaidMediaPayload { get; init; }

    public Gift? Gift { get; init; }

    public int? PremiumSubscriptionDuration { get; init; }
}

public sealed class TransactionPartnerChat : TransactionPartner
{
    public override TransactionPartnerType Type => TransactionPartnerType.Chat;

    public required Chat Chat { get; init; }

    public Gift? Gift { get; init; }
}

public sealed class TransactionPartnerAffiliateProgram : TransactionPartner
{
    public override TransactionPartnerType Type => TransactionPartnerType.AffiliateProgram;

    public User? SponsorUser { get; init; }

    public required int CommissionPerMille { get; init; }
}

public sealed class TransactionPartnerFragment : TransactionPartner
{
    public override TransactionPartnerType Type => TransactionPartnerType.Fragment;

    public RevenueWithdrawalState? WithdrawalState { get; init; }
}

public sealed class TransactionPartnerTelegramAds : TransactionPartner
{
    public override TransactionPartnerType Type => TransactionPartnerType.TelegramAds;
}

public sealed class TransactionPartnerTelegramApi : TransactionPartner
{
    public override TransactionPartnerType Type => TransactionPartnerType.TelegramApi;

    public required int RequestCount { get; init; }
}

public sealed class TransactionPartnerOther : TransactionPartner
{
    public override TransactionPartnerType Type => TransactionPartnerType.Other;
}
