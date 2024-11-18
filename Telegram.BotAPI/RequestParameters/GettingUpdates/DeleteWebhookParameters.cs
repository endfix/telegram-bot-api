namespace Telegram.BotAPI.RequestParameters.GettingUpdates;

public sealed class DeleteWebhookParameters
{
    /// <summary>
    /// Pass True to drop all pending updates
    /// </summary>
    public bool DropPendingUpdates { get; set; }
}
