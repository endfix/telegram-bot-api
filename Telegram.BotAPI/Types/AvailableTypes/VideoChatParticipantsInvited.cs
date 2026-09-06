using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Describes a service message about new members invited to a video chat.
/// </summary>
public sealed class VideoChatParticipantsInvited
{
    /// <summary>New members invited to the video chat.</summary>
    public required IReadOnlyList<User> Users { get; init; }
}
