using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

public sealed class GetMyShortDescriptionParameters : ApiRequestParameters
{
    public string? LanguageCode { get; init; }
}
