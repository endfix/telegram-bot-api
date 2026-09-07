namespace Endfix.Telegram.BotAPI.Enums;

/// <summary>Identifies why payment for a suggested post was refunded.</summary>
public enum SuggestedPostRefundedReason
{
    /// <summary>The suggested post was deleted.</summary>
    PostDeleted,

    /// <summary>The payment was explicitly refunded.</summary>
    PaymentRefunded
}
