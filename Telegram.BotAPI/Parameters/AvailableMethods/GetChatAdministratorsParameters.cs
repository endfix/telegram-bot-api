using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>getChatAdministrators</c> method.
/// </summary>
public sealed class GetChatAdministratorsParameters : ApiRequestParameters
{
    public required ChatIdSource ChatId { get; init; }

    public bool? ReturnBots { get; init; }
}
