using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

public sealed class SetMyDescriptionParameters : ApiRequestParameters
{
    public string? Description { get; init; }

    public string? LanguageCode { get; init; }
}
