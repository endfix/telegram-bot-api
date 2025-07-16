namespace Telegram.BotAPI.Parameters;

public sealed class SetMyDescriptionParameters : ApiRequestParameters
{
    public string Description { get; set; }

    public string LanguageCode { get; set; }
}
