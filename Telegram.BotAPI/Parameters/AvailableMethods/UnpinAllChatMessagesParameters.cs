using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>unpinAllChatMessages</c> method.
/// </summary>
public sealed class UnpinAllChatMessagesParameters : ApiRequestParameters
{
    /// <summary>Target chat identifier or channel username.</summary>
    public required ChatIdSource ChatId { get; init; }
}
