using System.Collections.Generic;
using Telegram.BotAPI.Types.AvailableTypes;

namespace Telegram.BotAPI.Types.Games;

public sealed class Game
{
    public string Title { get; set; }

    public string Description { get; set; }

    public List<PhotoSize> Photo { get; set; }

    public string Text { get; set; }

    public List<MessageEntity> TextEntities { get; set; }

    public Animation Animation { get; set; }
}
