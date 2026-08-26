using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

public sealed class GetMyDescriptionParameters : ApiRequestParameters
{
    public string? LanguageCode { get; init; }
}
