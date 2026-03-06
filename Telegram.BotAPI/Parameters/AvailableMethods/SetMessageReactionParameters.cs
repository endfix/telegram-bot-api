using System.Collections.Generic;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class SetMessageReactionParameters : ApiRequestParameters
{
    public required object ChatId { get; init; }

    public required int MessageId { get; init; }

    public IReadOnlyList<ReactionType>? Reaction { get; init; }

    public bool? IsBig { get; init; }
}
