using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

public sealed class GetChatMenuButtonParameters : ApiRequestParameters
{
    public long? ChatId { get; init; }
}
