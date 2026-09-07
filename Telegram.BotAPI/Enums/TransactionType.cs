namespace Endfix.Telegram.BotAPI.Enums;

/// <summary>Identifies the kind of Telegram Stars transaction initiated by a bot.</summary>
public enum TransactionType
{
    /// <summary>Payment of an invoice.</summary>
    InvoicePayment,

    /// <summary>Payment for paid media.</summary>
    PaidMediaPayment,

    /// <summary>Purchase of a gift.</summary>
    GiftPurchase,

    /// <summary>Purchase of a Telegram Premium subscription.</summary>
    PremiumPurchase,

    /// <summary>Transfer involving a managed business account.</summary>
    BusinessAccountTransfer
}
