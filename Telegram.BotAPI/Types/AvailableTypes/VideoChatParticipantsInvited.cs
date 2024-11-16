using System.Collections.Generic;

namespace Telegram.BotAPI.Types.AvailableTypes;

public sealed class VideoChatParticipantsInvited
{
    public List<User> Users { get; set; }
}
