using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class DeleteMyCommandsParameters : ApiRequestParameters
{
    public BotCommandScope? Scope { get; init; }

    public string? LanguageCode { get; init; }
}
