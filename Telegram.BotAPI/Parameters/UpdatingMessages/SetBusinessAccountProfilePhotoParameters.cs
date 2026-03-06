using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class SetBusinessAccountProfilePhotoParameters : ApiRequestParameters
{
    public required string BusinessConnectionId { get; init; }

    public required InputProfilePhoto Photo { get; init; }

    public bool? IsPublic { get; init; }
}
