namespace Telegram.BotAPI.Types;

public sealed class Game
{
    public string Title { get; set; }

    public string Description { get; set; }

    public PhotoSize[] Photo { get; set; }

    public string Text { get; set; }

    public MessageEntity[] TextEntities { get; set; }

    public Animation Animation { get; set; }
}
