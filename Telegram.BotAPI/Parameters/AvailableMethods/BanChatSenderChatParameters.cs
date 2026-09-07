using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>banChatSenderChat</c> method.
/// </summary>
public sealed class BanChatSenderChatParameters : ApiRequestParameters
{
    /// <summary>Gets the unique identifier or username of the target channel or supergroup.</summary>
    public required ChatIdSource ChatId { get; init; }

    /// <summary>Gets the unique identifier of the sender chat to ban.</summary>
    public required long SenderChatId { get; init; }
}
