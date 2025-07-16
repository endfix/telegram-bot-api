using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class DeleteMyCommandsParameters : ApiRequestParameters
{
    public BotCommandScope Scope { get; set; }

    public string LanguageCode { get; set; }
}
