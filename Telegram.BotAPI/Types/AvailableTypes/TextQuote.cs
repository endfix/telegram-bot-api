namespace Telegram.BotAPI.Types;

public sealed class TextQuote
{
    public string Text { get; set; }

    public MessageEntity[] Entities { get; set; }

    public int Position { get; set; }

    public bool IsManual { get; set; }
}
