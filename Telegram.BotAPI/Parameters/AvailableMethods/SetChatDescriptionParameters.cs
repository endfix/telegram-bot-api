using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class SetChatDescriptionParameters : ApiRequestParameters
{
    public required ChatIdSource ChatId { get; init; }

    public string? Description { get; init; }
}
