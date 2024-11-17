using System.Collections.Generic;

namespace Telegram.BotAPI.Types.GettingUpdates;

/// <summary>
/// Describes the current status of a webhook.
/// </summary>
public sealed class WebhookInfo
{
    /// <summary>
    /// Webhook URL, may be empty if webhook is not set up
    /// </summary>
    public string Url { get; set; }

    /// <summary>
    /// True, if a custom certificate was provided for webhook certificate checks
    /// </summary>
    public bool HasCustomCertificate { get; set; }

    /// <summary>
    /// Number of updates awaiting delivery
    /// </summary>
    public int PendingUpdateCount { get; set; }

    /// <summary>
    /// Optional. Currently used webhook IP address
    /// </summary>
    public string IpAddress { get; set; }

    /// <summary>
    /// Optional. Unix time for the most recent error that happened when trying to deliver an update via webhook
    /// </summary>
    public int LastErrorDate { get; set; }

    /// <summary>
    /// Optional. Error message in human-readable format for the most recent error that happened when trying to deliver an update via webhook
    /// </summary>
    public string LastErrorMessage { get; set; }

    /// <summary>
    /// Optional. Unix time of the most recent error that happened when trying to synchronize available updates with Telegram datacenters
    /// </summary>
    public int LastSynchronizationErrorDate { get; set; }

    /// <summary>
    /// Optional. The maximum allowed number of simultaneous HTTPS connections to the webhook for update delivery
    /// </summary>
    public int MaxConnections { get; set; }

    /// <summary>
    /// Optional. A list of update types the bot is subscribed to. Defaults to all update types except chat_member
    /// </summary>
    public List<string> AllowedUpdates { get; set; }
}
