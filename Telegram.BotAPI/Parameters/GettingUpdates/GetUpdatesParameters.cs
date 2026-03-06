using System.Collections.Generic;

namespace Telegram.BotAPI.Parameters;

public sealed class GetUpdatesParameters : ApiRequestParameters
{
    public long? Offset { get; init; }

    public int? Limit { get; init; }

    public int? Timeout { get; init; }

    public IReadOnlyList<string>? AllowedUpdates { get; init; }
}
