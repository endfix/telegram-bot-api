namespace Telegram.BotAPI.Parameters;

public sealed class DeleteWebhookParameters : ApiRequestParameters
{
    public bool DropPendingUpdates { get; set; }
}
