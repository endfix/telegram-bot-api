namespace Telegram.BotAPI.Types.Payments;

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

public sealed class RevenueWithdrawalStatePending : RevenueWithdrawalState
{
    public override string Type => Types.PENDING;
}

public sealed class RevenueWithdrawalStateSucceeded : RevenueWithdrawalState
{
    public override string Type => Types.SUCCEEDED;

    public int Date { get; set; }

    public string Url { get; set; }
}

public sealed class RevenueWithdrawalStateFailed : RevenueWithdrawalState
{
    public override string Type => Types.FAILED;
}
