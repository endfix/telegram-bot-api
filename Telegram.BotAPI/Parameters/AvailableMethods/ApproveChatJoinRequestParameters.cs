using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>approveChatJoinRequest</c> method.
/// </summary>
public sealed class ApproveChatJoinRequestParameters : ApiRequestParameters
{
    /// <summary>Gets the unique identifier or username of the target channel or supergroup.</summary>
    public required ChatIdSource ChatId { get; init; }

    /// <summary>Gets the unique identifier of the user whose join request is approved.</summary>
    public required long UserId { get; init; }
}
