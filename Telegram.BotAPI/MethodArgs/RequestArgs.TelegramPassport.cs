using System.Collections.Generic;
using Telegram.BotAPI.Types.TelegramPassport;

namespace Telegram.BotAPI.MethodArgs;

public sealed class SetPassportDataErrorsArgs : RequestArgs
{
    public long UserId { get; set; }

    public List<PassportElementError> Errors { get; set; }
}
