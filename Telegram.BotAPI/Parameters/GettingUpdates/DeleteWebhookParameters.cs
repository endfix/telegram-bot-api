using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

public sealed class DeleteWebhookParameters : ApiRequestParameters
{
    public bool? DropPendingUpdates { get; init; }
}
