namespace Telegram.BotAPI.Types.Payments;

/// <summary>
/// This object describes the state of a revenue withdrawal operation. Currently, it can be one of
/// <see cref="RevenueWithdrawalStatePending">RevenueWithdrawalStatePending<\see> or
/// <see cref="RevenueWithdrawalStateSucceeded">RevenueWithdrawalStateSucceeded<\see> or
/// <see cref="RevenueWithdrawalStateFailed">RevenueWithdrawalStateFailed<\see>
/// </summary>
public abstract class RevenueWithdrawalState
{
    public abstract string Type { get; }

    public static class Types
    {
        public const string PENDING = "pending";

        public const string SUCCEEDED = "succeeded";

        public const string FAILED = "failed";
    }
}

/// <summary>
/// The withdrawal is in progress.
/// </summary>
public sealed class RevenueWithdrawalStatePending : RevenueWithdrawalState
{
    /// <summary>
    /// Type of the state, always “pending”
    /// </summary>
    public override string Type => Types.PENDING;
}

/// <summary>
/// The withdrawal succeeded.
/// </summary>
public sealed class RevenueWithdrawalStateSucceeded : RevenueWithdrawalState
{
    /// <summary>
    /// Type of the state, always “succeeded”
    /// </summary>
    public override string Type => Types.SUCCEEDED;

    /// <summary>
    /// Date the withdrawal was completed in Unix time
    /// </summary>
    public int Date { get; set; }

    /// <summary>
    /// An HTTPS URL that can be used to see transaction details
    /// </summary>
    public string Url { get; set; }
}

/// <summary>
/// The withdrawal failed and the transaction was refunded.
/// </summary>
public sealed class RevenueWithdrawalStateFailed : RevenueWithdrawalState
{
    /// <summary>
    /// Type of the state, always “failed”
    /// </summary>
    public override string Type => Types.FAILED;
}
