using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

public sealed class VerifyChatParameters : ApiRequestParameters
{
    public required ChatIdSource ChatId { get; init; }

    public string? CustomDescription { get; init; }
}
