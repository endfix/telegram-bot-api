using Telegram.BotAPI.Protocol;

namespace Telegram.BotAPI.Parameters;

public sealed class SetBusinessAccountUsernameParameters : ApiRequestParameters
{
    public required string BusinessConnectionId { get; init; }

    public string? Username { get; init; }
}
