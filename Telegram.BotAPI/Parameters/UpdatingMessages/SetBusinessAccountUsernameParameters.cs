using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>setBusinessAccountUsername</c> method.
/// </summary>
public sealed class SetBusinessAccountUsernameParameters : ApiRequestParameters
{
    public required string BusinessConnectionId { get; init; }

    public string? Username { get; init; }
}
