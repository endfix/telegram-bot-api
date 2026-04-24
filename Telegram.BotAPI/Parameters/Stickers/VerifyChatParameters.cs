using Telegram.BotAPI.Protocol;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class VerifyChatParameters : ApiRequestParameters
{
    public required ChatIdSource ChatId { get; init; }

    public string? CustomDescription { get; init; }
}
