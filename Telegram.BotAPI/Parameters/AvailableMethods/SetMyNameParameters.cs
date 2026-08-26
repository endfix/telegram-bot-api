using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

public sealed class SetMyNameParameters : ApiRequestParameters
{
    public string? Name { get; init; }

    public string? LanguageCode { get; init; }
}
