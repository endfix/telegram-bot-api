using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

public sealed class SetBusinessAccountBioParameters : ApiRequestParameters
{
    public required string BusinessConnectionId { get; init; }

    public string? Bio { get; init; }
}
