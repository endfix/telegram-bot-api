using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

public class GetMyNameParameters : ApiRequestParameters
{
    public string? LanguageCode { get; init; }
}
