using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>setBusinessAccountBio</c> method.
/// </summary>
public sealed class SetBusinessAccountBioParameters : ApiRequestParameters
{
    /// <summary>Identifier of the business connection.</summary>
    public required string BusinessConnectionId { get; init; }

    /// <summary>New bio, from 0 through 140 characters.</summary>
    public string? Bio { get; init; }
}
