using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>removeChatVerification</c> method.
/// </summary>
public sealed class RemoveChatVerificationParameters : ApiRequestParameters
{
    /// <summary>Target bot or channel identifier or username.</summary>
    public required ChatIdSource ChatId { get; init; }
}
