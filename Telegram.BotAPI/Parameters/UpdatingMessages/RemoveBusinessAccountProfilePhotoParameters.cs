using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

public sealed class RemoveBusinessAccountProfilePhotoParameters : ApiRequestParameters
{
    public required string BusinessConnectionId { get; init; }

    public bool? IsPublic { get; init; }
}
