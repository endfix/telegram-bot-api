using System.Collections.Generic;

namespace Telegram.BotAPI.Types.AvailableTypes;

public sealed class ChatShared
{
    public int RequestId { get; set; }

    public long ChatId { get; set; }

    public string Title { get; set; }

    public string Username { get; set; }

    public List<PhotoSize> Photo { get; set; }
}
