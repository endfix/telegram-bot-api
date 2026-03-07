using System.Collections.Generic;

namespace Telegram.BotAPI.Types;

public sealed class PollOption
{
    public required string Text { get; init; }

    public IReadOnlyList<MessageEntity>? TextEntities { get; init; }

    public required int VoterCount { get; init; }
}
