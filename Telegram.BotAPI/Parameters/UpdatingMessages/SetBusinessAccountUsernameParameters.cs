using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>setBusinessAccountUsername</c> method.
/// </summary>
public sealed class SetBusinessAccountUsernameParameters : ApiRequestParameters
{
    /// <summary>Identifier of the business connection.</summary>
    public required string BusinessConnectionId { get; init; }

    /// <summary>New username, from 0 through 32 characters.</summary>
    public string? Username { get; init; }
}
