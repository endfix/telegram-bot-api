using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>removeUserVerification</c> method.
/// </summary>
public sealed class RemoveUserVerificationParameters : ApiRequestParameters
{
    public required long UserId { get; init; }
}
