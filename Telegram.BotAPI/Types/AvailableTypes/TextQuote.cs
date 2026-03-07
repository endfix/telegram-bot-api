using System.Collections.Generic;

namespace Telegram.BotAPI.Types;

public sealed class TextQuote
{
    public required string Text { get; init; }

    public IReadOnlyList<MessageEntity>? Entities { get; init; }

    public required int Position { get; init; }

    public bool? IsManual { get; init; }
}
