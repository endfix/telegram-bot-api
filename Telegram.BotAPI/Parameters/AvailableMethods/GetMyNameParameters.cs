using Telegram.BotAPI.Protocol;

namespace Telegram.BotAPI.Parameters;

public class GetMyNameParameters : ApiRequestParameters
{
    public string? LanguageCode { get; init; }
}
