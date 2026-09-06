using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>getUserPersonalChatMessages</c> method.
/// </summary>
public sealed class GetUserPersonalChatMessagesParameters : ApiRequestParameters
{
    public required long UserId { get; init; }

    public required int Limit { get; init; }
}
