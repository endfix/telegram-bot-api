using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

public sealed class VerifyUserParameters : ApiRequestParameters
{
    public required long UserId { get; init; }

    public string? CustomDescription { get; init; }
}
