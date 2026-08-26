using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

public sealed class SharedUser
{
    public required long UserId { get; init; }

    public string? FirstName { get; init; }

    public string? LastName { get; init; }

    public string? Username { get; init; }

    public IReadOnlyList<PhotoSize>? Photo { get; init; }
}
