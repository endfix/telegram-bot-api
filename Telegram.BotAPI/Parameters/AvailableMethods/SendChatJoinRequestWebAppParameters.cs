using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

public sealed class SendChatJoinRequestWebAppParameters : ApiRequestParameters
{
    public required string ChatJoinRequestQueryId { get; init; }

    public required string WebAppUrl { get; init; }
}
