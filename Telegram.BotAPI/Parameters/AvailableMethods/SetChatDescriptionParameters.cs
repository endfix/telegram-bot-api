using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>setChatDescription</c> method.
/// </summary>
public sealed class SetChatDescriptionParameters : ApiRequestParameters
{
    public required ChatIdSource ChatId { get; init; }

    public string? Description { get; init; }
}
