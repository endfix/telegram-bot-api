using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>replaceManagedBotToken</c> method.
/// </summary>
public sealed class ReplaceManagedBotTokenParameters : ApiRequestParameters
{
    public required long UserId { get; init; }
}
