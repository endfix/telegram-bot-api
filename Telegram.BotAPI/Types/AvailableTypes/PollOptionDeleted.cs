using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

public sealed class PollOptionDeleted
{
    public MaybeInaccessibleMessage? PollMessage { get; init; }

    public required string OptionPersistentId { get; init; }

    public required string OptionText { get; init; }

    public IReadOnlyList<MessageEntity>? OptionTextEntities { get; init; }
}
