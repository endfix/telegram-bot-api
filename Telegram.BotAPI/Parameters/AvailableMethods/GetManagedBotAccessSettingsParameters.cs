using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

public sealed class GetManagedBotAccessSettingsParameters : ApiRequestParameters
{
    public required long UserId { get; init; }
}
