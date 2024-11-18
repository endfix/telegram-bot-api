using System.Collections.Generic;
using Telegram.BotAPI.Types.AvailableTypes;

namespace Telegram.BotAPI.RequestParameters.GettingUpdates;

public class SetWebhookParameters
{
    /// <summary>
    /// HTTPS URL to send updates to.Use an empty string to remove webhook integration
    /// </summary>
    public string Url { get; set; }

    /// <summary>
    /// Upload your public key certificate so that the root certificate in use can be checked. 
    /// See our <see href="https://core.telegram.org/bots/self-signed">self-signed guide</see> for details.
    /// </summary>
    public InputFile Certificate {  get; set; }

    /// <summary>
    /// The fixed IP address which will be used to send webhook requests instead of the IP address resolved through DNS
    /// </summary>
    public string IpAddress { get; set; } = string.Empty;

    /// <summary>
    /// The maximum allowed number of simultaneous HTTPS connections to the webhook for update delivery, 1 - 100.Defaults to 40. 
    /// Use lower values to limit the load on your bot's server, and higher values to increase your bot's throughput.
    /// </summary>
    public int MaxConnections { get; set; }

    /// <summary>
    /// A JSON - serialized list of the update types you want your bot to receive.For example,
    /// specify["message", "edited_channel_post", "callback_query"] to only receive updates of these types.
    /// See <see cref="Types.GettingUpdates.Update">Update</see> for a complete list of available update types.
    /// Specify an empty list to receive all update types except chat_member, message_reaction, and message_reaction_count(default).
    /// If not specified, the previous setting will be used.
    /// Please note that this parameter doesn't affect updates created before the call to the setWebhook, so unwanted updates may be received for a short period of time.
    /// </summary>
    public List<string> AllowedUpdates { get; set; }

    /// <summary>
    /// Pass True to drop all pending updates
    /// </summary>
    public bool DropPendingUpdates { get; set; }

    /// <summary>
    /// A secret token to be sent in a header “X-Telegram-Bot-Api-Secret-Token” in every webhook request, 1-256 characters.
    /// Only characters A-Z, a-z, 0-9, _ and - are allowed. The header is useful to ensure that the request comes from a webhook set by you.
    /// </summary>
    public string SecretToken { get; set; }
}
