using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>setBusinessAccountProfilePhoto</c> method.
/// </summary>
public sealed class SetBusinessAccountProfilePhotoParameters : ApiRequestParameters
{
    public required string BusinessConnectionId { get; init; }

    public required InputProfilePhoto Photo { get; init; }

    public bool? IsPublic { get; init; }
}
