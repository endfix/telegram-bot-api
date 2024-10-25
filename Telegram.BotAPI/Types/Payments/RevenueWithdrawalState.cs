namespace Telegram.BotAPI.Types.Payments;

// https://core.telegram.org/bots/api#revenuewithdrawalstate
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

// https://core.telegram.org/bots/api#revenuewithdrawalstatepending
public sealed class RevenueWithdrawalStatePending : RevenueWithdrawalState
{
    public override string Type => Types.PENDING;
}

// https://core.telegram.org/bots/api#revenuewithdrawalstatesucceeded
public sealed class RevenueWithdrawalStateSucceeded : RevenueWithdrawalState
{
    public override string Type => Types.SUCCEEDED;

    public int Date { get; set; }

    public string Url { get; set; }
}

// https://core.telegram.org/bots/api#revenuewithdrawalstatefailed
public sealed class RevenueWithdrawalStateFailed : RevenueWithdrawalState
{
    public override string Type => Types.FAILED;
}