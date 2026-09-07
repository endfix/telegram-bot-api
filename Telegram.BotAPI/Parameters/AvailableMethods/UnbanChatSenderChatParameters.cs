using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>unbanChatSenderChat</c> method.
/// </summary>
public sealed class UnbanChatSenderChatParameters : ApiRequestParameters
{
    /// <summary>Target supergroup or channel identifier or channel username.</summary>
    public required ChatIdSource ChatId { get; init; }

    /// <summary>Target sender chat identifier.</summary>
    public required long SenderChatId { get; init; }
}
