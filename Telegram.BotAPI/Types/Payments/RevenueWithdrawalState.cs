using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

public abstract class RevenueWithdrawalState
{
    public abstract RevenueWithdrawalStateTypes Type { get; }
}

public sealed class RevenueWithdrawalStatePending : RevenueWithdrawalState
{
    public override RevenueWithdrawalStateTypes Type => RevenueWithdrawalStateTypes.Pending;
}

public sealed class RevenueWithdrawalStateSucceeded : RevenueWithdrawalState
{
    public override RevenueWithdrawalStateTypes Type => RevenueWithdrawalStateTypes.Succeeded;

    public required int Date { get; init; }

    public required string Url { get; init; }
}

public sealed class RevenueWithdrawalStateFailed : RevenueWithdrawalState
{
    public override RevenueWithdrawalStateTypes Type => RevenueWithdrawalStateTypes.Failed;
}
