using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>setBusinessAccountName</c> method.
/// </summary>
public sealed class SetBusinessAccountNameParameters : ApiRequestParameters
{
    /// <summary>Identifier of the business connection.</summary>
    public required string BusinessConnectionId { get; init; }

    /// <summary>New first name, from 1 through 64 characters.</summary>
    public required string FirstName { get; init; }

    /// <summary>New last name, from 0 through 64 characters.</summary>
    public string? LastName { get; init; }
}
