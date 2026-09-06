using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Enums;
using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>getUpdates</c> method.
/// </summary>
public sealed class GetUpdatesParameters : ApiRequestParameters
{
    /// <summary>
    /// Identifier of the first update to be returned. It must be greater by one than the highest previously received update identifier.
    /// </summary>
    public long? Offset { get; init; }

    /// <summary>
    /// Maximum number of updates to retrieve. Accepted values are 1-100; the default is 100.
    /// </summary>
    public int? Limit { get; init; }

    /// <summary>
    /// Long-polling timeout in seconds. The default is 0, which enables short polling.
    /// </summary>
    public int? Timeout { get; init; }

    /// <summary>
    /// Update types to receive. If omitted, the previous setting is preserved.
    /// </summary>
    public IReadOnlyList<UpdateType>? AllowedUpdates { get; init; }
}
