namespace Telegram.BotAPI.Parameters;

public sealed class VerifyChatParameters : ApiRequestParameters
{
    public required object ChatId { get; init; }

    public string? CustomDescription { get; init; }
}
