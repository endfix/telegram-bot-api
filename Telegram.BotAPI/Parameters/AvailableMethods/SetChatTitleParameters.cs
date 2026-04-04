using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class SetChatTitleParameters : ApiRequestParameters
{
    public required ChatIdSource ChatId { get; init; }

    public required string Title { get; init; }
}
