using System.Collections.Generic;
using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

public sealed class WebhookInfo
{
    public required string Url { get; init; }

    public required bool HasCustomCertificate { get; init; }

    public required int PendingUpdateCount { get; init; }

    public string? IpAddress { get; init; }

    public long? LastErrorDate { get; init; }

    public string? LastErrorMessage { get; init; }

    public long? LastSynchronizationErrorDate { get; init; }

    public int? MaxConnections { get; init; }

    public IReadOnlyList<UpdateType>? AllowedUpdates { get; init; }
}
