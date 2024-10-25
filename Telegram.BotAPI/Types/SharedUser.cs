using System.Collections.Generic;

namespace Telegram.BotAPI.Types
{
    // https://core.telegram.org/bots/api#shareduser
    public class SharedUser
    {
        public long UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public List<PhotoSize> Photo { get; set; }
    }
}
