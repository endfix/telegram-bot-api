using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>getManagedBotToken</c> method.
/// </summary>
public sealed class GetManagedBotTokenParameters : ApiRequestParameters
{
    /// <summary>Identifier of the managed bot.</summary>
    public required long UserId { get; init; }
}
