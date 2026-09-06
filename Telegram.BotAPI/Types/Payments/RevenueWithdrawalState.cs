using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Base type for the state of a revenue withdrawal.</summary>
public abstract class RevenueWithdrawalState
{
    /// <summary>Gets the withdrawal state type.</summary>
    public abstract RevenueWithdrawalStateType Type { get; }
}

/// <summary>Indicates that the revenue withdrawal is in progress.</summary>
public sealed class RevenueWithdrawalStatePending : RevenueWithdrawalState
{
    public override RevenueWithdrawalStateType Type => RevenueWithdrawalStateType.Pending;
}

/// <summary>Indicates that the revenue withdrawal was completed successfully.</summary>
public sealed class RevenueWithdrawalStateSucceeded : RevenueWithdrawalState
{
    public override RevenueWithdrawalStateType Type => RevenueWithdrawalStateType.Succeeded;

    /// <summary>Date when the withdrawal was completed, in Unix time.</summary>
    public required int Date { get; init; }

    /// <summary>URL to the withdrawal receipt.</summary>
    public required string Url { get; init; }
}

/// <summary>Indicates that the revenue withdrawal failed.</summary>
public sealed class RevenueWithdrawalStateFailed : RevenueWithdrawalState
{
    public override RevenueWithdrawalStateType Type => RevenueWithdrawalStateType.Failed;
}
