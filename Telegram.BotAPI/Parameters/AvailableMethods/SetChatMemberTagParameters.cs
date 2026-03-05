namespace Telegram.BotAPI.Parameters;

public sealed class SetChatMemberTagParameters : ApiRequestParameters
{
    public required object ChatId { get; set; }

    public required long UserId { get; set; }

    public string? Tag { get; set; }
}
