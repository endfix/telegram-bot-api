using Telegram.BotAPI.Protocol;

namespace Telegram.BotAPI.Parameters;

public sealed class GetUserPersonalChatMessagesParameters : ApiRequestParameters
{
    public required long UserId { get; init; }

    public required int Limit { get; init; }
}
