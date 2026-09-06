using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Enums;
using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for configuring an outgoing webhook with the <c>setWebhook</c> method.
/// </summary>
public class SetWebhookParameters : ApiRequestParameters
{
    /// <summary>
    /// HTTPS URL where Telegram sends incoming updates. Set an empty string to remove the webhook.
    /// </summary>
    public required string Url { get; init; }

    /// <summary>
    /// Public key certificate for checking a self-signed webhook certificate.
    /// </summary>
    public InputFile? Certificate { get; init; }

    /// <summary>
    /// Fixed IP address used for webhook requests instead of the address resolved through DNS.
    /// </summary>
    public string? IpAddress { get; init; }

    /// <summary>
    /// Maximum number of simultaneous HTTPS connections used for delivering updates. Accepted values are 1-100; the default is 40.
    /// </summary>
    public int? MaxConnections { get; init; }

    /// <summary>
    /// Update types that should be delivered to the webhook. If omitted, the previous setting is preserved.
    /// </summary>
    public IReadOnlyList<UpdateType>? AllowedUpdates { get; init; }

    /// <summary>
    /// Indicates whether all pending updates should be discarded.
    /// </summary>
    public bool? DropPendingUpdates { get; init; }

    /// <summary>
    /// Secret token included in the <c>X-Telegram-Bot-Api-Secret-Token</c> header of webhook requests. It must contain 1-256 characters from <c>A-Z</c>, <c>a-z</c>, <c>0-9</c>, <c>_</c>, and <c>-</c>.
    /// </summary>
    public string? SecretToken { get; init; }
}
