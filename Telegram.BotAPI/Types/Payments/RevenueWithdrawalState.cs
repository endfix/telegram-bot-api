using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

public abstract class RevenueWithdrawalState
{
    public abstract RevenueWithdrawalStateType Type { get; }
}

public sealed class RevenueWithdrawalStatePending : RevenueWithdrawalState
{
    public override RevenueWithdrawalStateType Type => RevenueWithdrawalStateType.Pending;
}

public sealed class RevenueWithdrawalStateSucceeded : RevenueWithdrawalState
{
    public override RevenueWithdrawalStateType Type => RevenueWithdrawalStateType.Succeeded;

    public required int Date { get; init; }

    public required string Url { get; init; }
}

public sealed class RevenueWithdrawalStateFailed : RevenueWithdrawalState
{
    public override RevenueWithdrawalStateType Type => RevenueWithdrawalStateType.Failed;
}
