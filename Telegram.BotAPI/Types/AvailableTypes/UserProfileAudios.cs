using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Represents the audios displayed on a user's profile.
/// </summary>
public sealed class UserProfileAudios
{
    /// <summary>Total number of profile audios for the target user.</summary>
    public required int TotalCount {  get; init; }

    /// <summary>Requested profile audios.</summary>
    public required IReadOnlyList<Audio> Audios { get; init; }
}
