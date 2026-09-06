using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>getManagedBotAccessSettings</c> method.
/// </summary>
public sealed class GetManagedBotAccessSettingsParameters : ApiRequestParameters
{
    public required long UserId { get; init; }
}
