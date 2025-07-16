namespace Telegram.BotAPI.Parameters;

public sealed class SetMyShortDescriptionParameters : ApiRequestParameters
{
    public string ShortDescription { get; set; }

    public string LanguageCode { get; set; }
}
