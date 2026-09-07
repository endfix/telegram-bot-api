using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>setMyProfilePhoto</c> method.
/// </summary>
public sealed class SetMyProfilePhotoParameters : ApiRequestParameters
{
    /// <summary>New profile photo.</summary>
    public required InputProfilePhoto Photo { get; init; }
}
