using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>deleteWebhook</c> method.
/// </summary>
public sealed class DeleteWebhookParameters : ApiRequestParameters
{
    /// <summary>
    /// Indicates whether all pending updates should be discarded.
    /// </summary>
    public bool? DropPendingUpdates { get; init; }
}
