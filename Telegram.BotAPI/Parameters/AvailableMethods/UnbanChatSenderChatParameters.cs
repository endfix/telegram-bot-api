using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>unbanChatSenderChat</c> method.
/// </summary>
public sealed class UnbanChatSenderChatParameters : ApiRequestParameters
{
    public required ChatIdSource ChatId { get; init; }

    public required long SenderChatId { get; init; }
}
