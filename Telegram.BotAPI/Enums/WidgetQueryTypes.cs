namespace Endfix.Telegram.BotAPI.Enums;

/// <summary>Identifies the kind of a query sent from a widget.</summary>
public enum WidgetQueryTypes
{
    /// <summary>The query contains data for the bot.</summary>
    Data,

    /// <summary>The query contains data signed by the user's TON wallet.</summary>
    SignData,

    /// <summary>The query reports a transaction sent from the user's TON wallet.</summary>
    SentTransaction
}
