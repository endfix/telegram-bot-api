namespace Endfix.Telegram.BotAPI.Enums;

/// <summary>Identifies the state of a revenue withdrawal.</summary>
public enum RevenueWithdrawalStateType
{
    /// <summary>The withdrawal is being processed.</summary>
    Pending,

    /// <summary>The withdrawal completed successfully.</summary>
    Succeeded,

    /// <summary>The withdrawal failed.</summary>
    Failed
}
