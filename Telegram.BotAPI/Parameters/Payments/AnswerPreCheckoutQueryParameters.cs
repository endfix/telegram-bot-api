namespace Telegram.BotAPI.Parameters;

public sealed class AnswerPreCheckoutQueryParameters : ApiRequestParameters
{
    public string PreCheckoutQueryId { get; set; }

    public bool Ok { get; set; }

    public string ErrorMessage { get; set; }
}
