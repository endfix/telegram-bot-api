using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

public sealed class PollAnswer
{
    public required string PollId { get; init; }

    public Chat? VoterChat { get; init; }

    public User? User { get; init; }

    public required IReadOnlyList<int> OptionIds { get; init; }

    public required IReadOnlyList<string> OptionPersistentIds { get; init; }
}
