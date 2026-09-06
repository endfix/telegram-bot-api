using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>setBusinessAccountBio</c> method.
/// </summary>
public sealed class SetBusinessAccountBioParameters : ApiRequestParameters
{
    public required string BusinessConnectionId { get; init; }

    public string? Bio { get; init; }
}
