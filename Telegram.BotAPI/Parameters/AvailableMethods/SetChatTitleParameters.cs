namespace Telegram.BotAPI.Parameters;

public sealed class SetChatTitleParameters : ApiRequestParameters
{
    public required object ChatId { get; init; }

    public required string Title { get; init; }
}
