using System.Collections.Generic;
using Telegram.BotAPI.Types.TelegramPassport;

namespace Telegram.BotAPI.RequestParameters.TelegramPassport;

public sealed class SetPassportDataErrorsParameters
{
    /// <summary>
    /// User identifier
    /// </summary>
    public long UserId { get; set; }

    /// <summary>
    /// A JSON-serialized array describing the errors
    /// </summary>
    public List<PassportElementError> Errors { get; set; }
}
