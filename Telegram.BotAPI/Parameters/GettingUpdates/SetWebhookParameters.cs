using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public class SetWebhookParameters : ApiRequestParameters
{
    public string Url { get; set; }

    public InputFile Certificate { get; set; }

    public string IpAddress { get; set; } = string.Empty;

    public int MaxConnections { get; set; }

    public string[] AllowedUpdates { get; set; }

    public bool DropPendingUpdates { get; set; }

    public string SecretToken { get; set; }
}
