using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class SetMyCommandsParameters : ApiRequestParameters
{
    public BotCommand[] Commands { get; set; }

    public BotCommandScope Scope { get; set; }

    public string LanguageCode { get; set; }
}
