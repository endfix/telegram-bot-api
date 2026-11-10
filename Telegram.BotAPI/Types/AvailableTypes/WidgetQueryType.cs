using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Describes the type of a query sent from a widget.</summary>
public abstract class WidgetQueryType
{
    /// <summary>Type of the query.</summary>
    public abstract WidgetQueryTypes Type { get; }
}

/// <summary>Describes a query that contains data for the bot.</summary>
public sealed class WidgetQueryTypeData : WidgetQueryType
{
    /// <summary>Type of the query, always <c>data</c>.</summary>
    public override WidgetQueryTypes Type => WidgetQueryTypes.Data;

    /// <summary>TON wallet card of the user, if it was sent with the query.</summary>
    public TonWalletCard? WalletCard { get; init; }
}

/// <summary>Describes a query that contains data signed by the user's TON wallet.</summary>
/// <remarks>
/// The data is signed for the domain <c>bot&lt;bot_id&gt;</c>, where <c>&lt;bot_id&gt;</c> is the
/// bot identifier.
/// </remarks>
public sealed class WidgetQueryTypeSignData : WidgetQueryType
{
    /// <summary>Type of the query, always <c>sign_data</c>.</summary>
    public override WidgetQueryTypes Type => WidgetQueryTypes.SignData;

    /// <summary>The wallet that signed the data.</summary>
    public required WidgetQueryWallet Wallet { get; init; }

    /// <summary>JSON-serialized signed data.</summary>
    public required string SignData { get; init; }
}

/// <summary>
/// Describes a query that reports a transaction sent from the user's TON wallet.
/// </summary>
public sealed class WidgetQueryTypeSentTransaction : WidgetQueryType
{
    /// <summary>Type of the query, always <c>sent_transaction</c>.</summary>
    public override WidgetQueryTypes Type => WidgetQueryTypes.SentTransaction;

    /// <summary>The wallet from which the transaction was sent.</summary>
    public required WidgetQueryWallet Wallet { get; init; }

    /// <summary>The <c>msg_hash</c> value of the transaction.</summary>
    public required string MsgHash { get; init; }
}
