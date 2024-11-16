using System.Collections.Generic;

namespace Telegram.BotAPI.Types.AvailableTypes;

public sealed class TextQuote
{
    public string Text { get; set; }

    public List<MessageEntity> Entities { get; set; }

    public int Position { get; set; }

    public bool IsManual { get; set; }
}
