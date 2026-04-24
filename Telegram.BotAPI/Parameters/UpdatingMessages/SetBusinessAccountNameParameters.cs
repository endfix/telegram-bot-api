using Telegram.BotAPI.Protocol;

namespace Telegram.BotAPI.Parameters;

public sealed class SetBusinessAccountNameParameters : ApiRequestParameters
{
    public required string BusinessConnectionId { get; init; }

    public required string FirstName { get; init; }

    public string? LastName { get; init; }
}
