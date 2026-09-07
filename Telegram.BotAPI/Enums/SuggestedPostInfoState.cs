namespace Endfix.Telegram.BotAPI.Enums;

/// <summary>Identifies the moderation state of a suggested post.</summary>
public enum SuggestedPostInfoState
{
    /// <summary>The suggested post awaits a decision.</summary>
    Pending,

    /// <summary>The suggested post was approved.</summary>
    Approved,

    /// <summary>The suggested post was declined.</summary>
    Declined
}
