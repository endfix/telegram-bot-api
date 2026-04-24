using Telegram.BotAPI.Protocol;

namespace Telegram.BotAPI.Parameters;

public sealed class ReadBusinessMessageParameters : ApiRequestParameters
{
    public required string BusinessConnectionId { get; init; }

    public required long ChatId { get; init; }

    public required long MessageId { get; init; }
}
