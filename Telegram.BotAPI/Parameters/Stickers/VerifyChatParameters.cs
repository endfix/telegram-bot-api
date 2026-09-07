using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>verifyChat</c> method.
/// </summary>
public sealed class VerifyChatParameters : ApiRequestParameters
{
    /// <summary>Target bot, supergroup or channel identifier or username. Channel direct messages cannot be verified.</summary>
    public required ChatIdSource ChatId { get; init; }

    /// <summary>Verification description, from 0 through 70 characters. Must be empty unless the organization may provide one.</summary>
    public string? CustomDescription { get; init; }
}
