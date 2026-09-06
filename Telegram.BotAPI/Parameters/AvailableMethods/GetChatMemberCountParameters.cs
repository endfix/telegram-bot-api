using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>getChatMemberCount</c> method.
/// </summary>
public sealed class GetChatMemberCountParameters : ApiRequestParameters
{
    public required ChatIdSource ChatId { get; init; }
}
