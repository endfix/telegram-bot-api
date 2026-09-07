using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>getUserPersonalChatMessages</c> method.
/// </summary>
public sealed class GetUserPersonalChatMessagesParameters : ApiRequestParameters
{
    /// <summary>Target user identifier.</summary>
    public required long UserId { get; init; }

    /// <summary>Maximum number of messages to return, from 1 through 20.</summary>
    public required int Limit { get; init; }
}
