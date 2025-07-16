namespace Telegram.BotAPI.Parameters;

public sealed class GetGameHighScoresParameters : ApiRequestParameters
{
    public long UserId { get; set; }

    public long ChatId { get; set; }

    public long MessageId { get; set; }

    public string InlineMessageId { get; set; }
}
