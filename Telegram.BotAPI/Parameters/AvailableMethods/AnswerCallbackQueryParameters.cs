namespace Telegram.BotAPI.Parameters;

public sealed class AnswerCallbackQueryParameters : ApiRequestParameters
{
    public string CallbackQueryId { get; set; }

    public string Text { get; set; }

    public bool ShowAlert { get; set; }

    public string Url { get; set; }

    public int CacheTime { get; set; }
}
