using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

public sealed class VideoChatParticipantsInvited
{
    public required IReadOnlyList<User> Users { get; init; }
}
