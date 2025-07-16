namespace Telegram.BotAPI.Parameters;

public sealed class SetMyNameParameters : ApiRequestParameters
{
    public string Name { get; set; }

    public string LanguageCode { get; set; }
}
