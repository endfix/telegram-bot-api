using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class GetChatAdministratorsParameters : ApiRequestParameters
{
    public required ChatIdSource ChatId { get; init; }
}
