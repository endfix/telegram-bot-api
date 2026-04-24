using Telegram.BotAPI.Protocol;

namespace Telegram.BotAPI.Parameters;

public sealed class GetMyDescriptionParameters : ApiRequestParameters
{
    public string? LanguageCode { get; init; }
}
