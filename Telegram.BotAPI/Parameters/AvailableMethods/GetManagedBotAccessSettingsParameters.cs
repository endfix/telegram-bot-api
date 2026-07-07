using Telegram.BotAPI.Protocol;

namespace Telegram.BotAPI.Parameters;

public sealed class GetManagedBotAccessSettingsParameters : ApiRequestParameters
{
    public required long UserId { get; init; }
}
