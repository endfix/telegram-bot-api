namespace Telegram.BotAPI.Requests.GettingUpdates;

public sealed class DeleteWebhookParameters : RequestParameters
{
    /// <summary>
    /// Pass True to drop all pending updates
    /// </summary>
    public bool DropPendingUpdates { get; set; }
}
