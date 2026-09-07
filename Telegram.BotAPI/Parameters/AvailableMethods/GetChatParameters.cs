using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>getChat</c> method.
/// </summary>
public sealed class GetChatParameters : ApiRequestParameters
{
    /// <summary>Target chat identifier or username.</summary>
    public required ChatIdSource ChatId { get; init; }
}
