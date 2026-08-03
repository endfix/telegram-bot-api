using System.Collections.Generic;
using Telegram.BotAPI.Enums;
using Telegram.BotAPI.Protocol;

namespace Telegram.BotAPI.Parameters;

public sealed class GetUpdatesParameters : ApiRequestParameters
{
    public long? Offset { get; init; }

    public int? Limit { get; init; }

    public int? Timeout { get; init; }

    public IReadOnlyList<UpdateType>? AllowedUpdates { get; init; }
}
