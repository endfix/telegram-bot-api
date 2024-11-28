using System.Collections.Generic;
using Telegram.BotAPI.Types.TelegramPassport;

namespace Telegram.BotAPI.Requests.TelegramPassport;

public sealed class SetPassportDataErrorsParameters : RequestParameters
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
