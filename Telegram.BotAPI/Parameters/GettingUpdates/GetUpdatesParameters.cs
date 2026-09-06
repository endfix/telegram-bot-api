using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Enums;
using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>getUpdates</c> method.
/// </summary>
public sealed class GetUpdatesParameters : ApiRequestParameters
{
    public long? Offset { get; init; }

    public int? Limit { get; init; }

    public int? Timeout { get; init; }

    public IReadOnlyList<UpdateType>? AllowedUpdates { get; init; }
}
