using System.Collections.Generic;

namespace Telegram.BotAPI.Types
{
    // https://core.telegram.org/bots/api#usersshared
    public class UsersShared
    {
        public int RequestId { get; set; }

        public List<SharedUser> Users { get; set; }
    }
}
