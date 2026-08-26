using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

public sealed class GetChatAdministratorsParameters : ApiRequestParameters
{
    public required ChatIdSource ChatId { get; init; }

    public bool? ReturnBots { get; init; }
}
