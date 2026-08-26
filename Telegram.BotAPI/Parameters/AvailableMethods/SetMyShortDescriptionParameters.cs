using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

public sealed class SetMyShortDescriptionParameters : ApiRequestParameters
{
    public string? ShortDescription { get; init; }

    public string? LanguageCode { get; init; }
}
