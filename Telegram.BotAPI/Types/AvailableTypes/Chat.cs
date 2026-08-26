using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

public sealed class Chat
{
    public required long Id { get; init; }

    public required ChatTypes Type { get; init; }

    public string? Title { get; init; }

    public string? Username { get; init; }

    public string? FirstName { get; init; }

    public string? LastName { get; init; }

    public bool? IsForum { get; init; }

    public bool? IsDirectMessages { get; init; }
}
