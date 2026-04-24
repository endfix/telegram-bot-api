using Telegram.BotAPI.Protocol;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class DeleteMessageParameters : ApiRequestParameters
{
    public required ChatIdSource ChatId { get; init; }

    public required long MessageId { get; init; }
}
