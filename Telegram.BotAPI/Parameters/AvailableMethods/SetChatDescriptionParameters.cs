namespace Telegram.BotAPI.Parameters;

public sealed class SetChatDescriptionParameters : ApiRequestParameters
{
    public required object ChatId { get; init; }

    public string? Description { get; init; }
}
