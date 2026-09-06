using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>deleteWebhook</c> method.
/// </summary>
public sealed class DeleteWebhookParameters : ApiRequestParameters
{
    public bool? DropPendingUpdates { get; init; }
}
