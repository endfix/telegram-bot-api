using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

public sealed class Chat
{
    public long Id { get; set; }

    public ChatTypes Type { get; set; }

    public string Title { get; set; }

    public string Username { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public bool IsForum { get; set; }

    public bool IsDirectMessages { get; set; }
}
