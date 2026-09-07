using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>removeBusinessAccountProfilePhoto</c> method.
/// </summary>
public sealed class RemoveBusinessAccountProfilePhotoParameters : ApiRequestParameters
{
    /// <summary>Identifier of the business connection.</summary>
    public required string BusinessConnectionId { get; init; }

    /// <summary>Whether to remove the public photo. Removing the main photo promotes the previous profile photo, if present.</summary>
    public bool? IsPublic { get; init; }
}
