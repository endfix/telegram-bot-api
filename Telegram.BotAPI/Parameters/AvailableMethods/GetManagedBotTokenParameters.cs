using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

public sealed class GetManagedBotTokenParameters : ApiRequestParameters
{
    public required long UserId { get; init; }
}
