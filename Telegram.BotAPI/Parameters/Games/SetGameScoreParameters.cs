namespace Telegram.BotAPI.Parameters;

public sealed class SetGameScoreParameters : ApiRequestParameters
{
    public long UserId { get; set; }

    public int Score { get; set; }

    public bool Force { get; set; }

    public bool DisableEditMessage { get; set; }

    public long ChatId { get; set; }

    public long MessageId { get; set; }

    public string InlineMessageId { get; set; }
}
