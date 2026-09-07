using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>setBusinessAccountProfilePhoto</c> method.
/// </summary>
public sealed class SetBusinessAccountProfilePhotoParameters : ApiRequestParameters
{
    /// <summary>Identifier of the business connection.</summary>
    public required string BusinessConnectionId { get; init; }

    /// <summary>New profile photo.</summary>
    public required InputProfilePhoto Photo { get; init; }

    /// <summary>Whether to set the public photo, which remains visible when the main photo is hidden by privacy settings. An account can have only one public photo.</summary>
    public bool? IsPublic { get; init; }
}
