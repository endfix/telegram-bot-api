using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class SetMyProfilePhotoParameters : ApiRequestParameters
{
    public required InputProfilePhoto Photo { get; set; }
}
