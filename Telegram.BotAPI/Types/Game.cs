using System.Collections.Generic;

namespace Telegram.BotAPI.Types
{
    // https://core.telegram.org/bots/api#game
    public class Game
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public List<PhotoSize> Photo { get; set; }

        public string Text { get; set; }

        public List<MessageEntity> TextEntities { get; set; }

        public Animation Animation { get; set; }
    }
}
