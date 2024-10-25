using System.Collections.Generic;

namespace Telegram.BotAPI.Types
{
    // https://core.telegram.org/bots/api#videochatparticipantsinvited
    public class VideoChatParticipantsInvited
    {
        public List<User> Users { get; set; }
    }
}
