using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>replaceManagedBotToken</c> method.
/// </summary>
public sealed class ReplaceManagedBotTokenParameters : ApiRequestParameters
{
    /// <summary>Identifier of the managed bot.</summary>
    public required long UserId { get; init; }
}
