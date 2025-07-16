namespace Telegram.BotAPI.Parameters;

public sealed class VerifyChatParameters : ApiRequestParameters
{
    public object ChatId { get; set; }

    public string CustomDescription { get; set; }
}
