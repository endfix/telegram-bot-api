namespace Endfix.Telegram.BotAPI.Enums;

/// <summary>Identifies the counterparty of a Telegram Stars transaction.</summary>
public enum TransactionPartnerType
{
    /// <summary>A Telegram user.</summary>
    User,

    /// <summary>A Telegram chat.</summary>
    Chat,

    /// <summary>An affiliate program.</summary>
    AffiliateProgram,

    /// <summary>The Fragment platform.</summary>
    Fragment,

    /// <summary>The Telegram Ads platform.</summary>
    TelegramAds,

    /// <summary>The Telegram Bot API.</summary>
    TelegramApi,

    /// <summary>Another or unspecified transaction partner.</summary>
    Other
}
