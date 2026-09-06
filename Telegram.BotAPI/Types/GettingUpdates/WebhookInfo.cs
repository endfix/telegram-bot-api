using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Describes the current status of a webhook.</summary>
public sealed class WebhookInfo
{
    /// <summary>Webhook URL, which may be empty if the webhook is not set up.</summary>
    public required string Url { get; init; }

    /// <summary>Indicates whether a custom certificate was provided for webhook certificate checks.</summary>
    public required bool HasCustomCertificate { get; init; }

    /// <summary>Number of updates awaiting delivery.</summary>
    public required int PendingUpdateCount { get; init; }

    /// <summary>Currently used webhook IP address, if available.</summary>
    public string? IpAddress { get; init; }

    /// <summary>Unix time of the most recent delivery error, if any.</summary>
    public long? LastErrorDate { get; init; }

    /// <summary>Human-readable message for the most recent delivery error, if any.</summary>
    public string? LastErrorMessage { get; init; }

    /// <summary>Unix time of the most recent synchronization error, if any.</summary>
    public long? LastSynchronizationErrorDate { get; init; }

    /// <summary>Maximum number of simultaneous HTTPS connections to the webhook, if configured.</summary>
    public int? MaxConnections { get; init; }

    /// <summary>List of update types to which the bot is subscribed, if explicitly configured.</summary>
    public IReadOnlyList<UpdateType>? AllowedUpdates { get; init; }
}
