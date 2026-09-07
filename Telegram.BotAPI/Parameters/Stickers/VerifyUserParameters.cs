using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>verifyUser</c> method.
/// </summary>
public sealed class VerifyUserParameters : ApiRequestParameters
{
    /// <summary>Target user identifier.</summary>
    public required long UserId { get; init; }

    /// <summary>Verification description, from 0 through 70 characters. Must be empty unless the organization may provide one.</summary>
    public string? CustomDescription { get; init; }
}
