namespace Telegram.BotAPI.Parameters;

public sealed class SetChatAdministratorCustomTitleParameters : ApiRequestParameters
{
    public required object ChatId { get; init; }

    public required long UserId { get; init; }

    public required string CustomTitle { get; init; }
}
