using Telegram.BotAPI.Protocol;

namespace Telegram.BotAPI.Parameters;

public sealed class ReplaceManagedBotTokenParameters : ApiRequestParameters
{
    public required long UserId { get; init; }
}
