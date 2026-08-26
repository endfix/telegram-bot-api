using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

public sealed class SetMyProfilePhotoParameters : ApiRequestParameters
{
    public required InputProfilePhoto Photo { get; init; }
}
