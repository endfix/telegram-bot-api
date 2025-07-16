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

    public int Date { get; set; }

    public string Url { get; set; }
}

public sealed class RevenueWithdrawalStateFailed : RevenueWithdrawalState
{
    public override RevenueWithdrawalStateTypes Type => RevenueWithdrawalStateTypes.Failed;
}
