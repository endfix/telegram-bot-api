using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

public sealed class SetMessageReactionParameters : ApiRequestParameters
{
    public required ChatIdSource ChatId { get; init; }

    public required long MessageId { get; init; }

    public IReadOnlyList<ReactionType>? Reaction { get; init; }

    public bool? IsBig { get; init; }
}
