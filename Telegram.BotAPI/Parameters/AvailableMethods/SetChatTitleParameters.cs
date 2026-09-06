using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>setChatTitle</c> method.
/// </summary>
public sealed class SetChatTitleParameters : ApiRequestParameters
{
    public required ChatIdSource ChatId { get; init; }

    public required string Title { get; init; }
}
