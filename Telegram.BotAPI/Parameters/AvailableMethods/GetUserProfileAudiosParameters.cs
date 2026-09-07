using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>getUserProfileAudios</c> method.
/// </summary>
public sealed class GetUserProfileAudiosParameters : ApiRequestParameters
{
    /// <summary>Target user identifier.</summary>
    public required long UserId { get; init; }

    /// <summary>Sequential number of the first profile audio to return.</summary>
    public int? Offset { get; init; }

    /// <summary>Maximum number of profile audio files to return, from 1 through 100. Defaults to 100.</summary>
    public int? Limit { get; init; }
}
