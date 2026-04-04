using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class RemoveChatVerificationParameters : ApiRequestParameters
{
    public required ChatIdSource ChatId { get; init; }
}
