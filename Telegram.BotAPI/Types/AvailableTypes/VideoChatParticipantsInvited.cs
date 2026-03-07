using System.Collections.Generic;

namespace Telegram.BotAPI.Types;

public sealed class VideoChatParticipantsInvited
{
    public required IReadOnlyList<User> Users { get; init; }
}
