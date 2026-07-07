using System.Collections.Generic;

namespace Telegram.BotAPI.Types;

public sealed class InputPollOption
{
    public required string Text { get; init; }

    public string? TextParseMode { get; init; }

    public IReadOnlyList<MessageEntity>? TextEntities { get; init; }

    public InputPollOptionMedia? Media { get; init; }
}
