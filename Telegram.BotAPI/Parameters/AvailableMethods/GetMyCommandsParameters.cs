using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

public sealed class GetMyCommandsParameters : ApiRequestParameters
{
    public BotCommandScope? Scope { get; init; }

    public string? LanguageCode { get; init; }
}
