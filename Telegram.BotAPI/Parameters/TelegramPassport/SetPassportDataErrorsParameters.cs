using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class SetPassportDataErrorsParameters : ApiRequestParameters
{
    public long UserId { get; set; }

    public PassportElementError[] Errors { get; set; }
}
