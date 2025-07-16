using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class SetBusinessAccountProfilePhotoParameters : ApiRequestParameters
{
    public string BusinessConnectionId { get; set; }

    public InputProfilePhoto Photo { get; set; }

    public bool IsPublic { get; set; }
}
