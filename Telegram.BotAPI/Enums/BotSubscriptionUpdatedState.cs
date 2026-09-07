namespace Endfix.Telegram.BotAPI.Enums;

/// <summary>Identifies the current state of a bot subscription.</summary>
public enum BotSubscriptionUpdatedState
{
    /// <summary>The subscription was canceled.</summary>
    Canceled,

    /// <summary>The subscription is active.</summary>
    Active,

    /// <summary>The subscription payment or activation failed.</summary>
    Failed
}
