using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>setBusinessAccountName</c> method.
/// </summary>
public sealed class SetBusinessAccountNameParameters : ApiRequestParameters
{
    public required string BusinessConnectionId { get; init; }

    public required string FirstName { get; init; }

    public string? LastName { get; init; }
}
