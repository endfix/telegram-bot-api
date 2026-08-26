using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Enums;
using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

public sealed class GetUpdatesParameters : ApiRequestParameters
{
    public long? Offset { get; init; }

    public int? Limit { get; init; }

    public int? Timeout { get; init; }

    public IReadOnlyList<UpdateType>? AllowedUpdates { get; init; }
}
