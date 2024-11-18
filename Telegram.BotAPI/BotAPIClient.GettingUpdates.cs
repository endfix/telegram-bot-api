using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.BotAPI.Core;
using Telegram.BotAPI.RequestParameters.GettingUpdates;
using Telegram.BotAPI.Types.GettingUpdates;

namespace Telegram.BotAPI;

public partial class BotAPIClient
{
    /// <summary>
    /// Use this method to receive incoming updates using long polling (<see href="https://en.wikipedia.org/wiki/Push_technology#Long_polling">wiki</see>).
    /// </summary>
    /// <param name="parameters"></param>
    /// <returns>Returns an Array of <see cref="Update">Update</see> objects.</returns>
    public async Task<ResponseAPI<List<Update>>> GetUpdatesAsync(GetUpdatesParameters parameters = null)
    {
        return await RequestAsync<List<Update>>("getUpdates", parameters);
    }

    /// <summary>
    /// Use this method to specify a URL and receive incoming updates via an outgoing webhook. Whenever there is an update for the bot,
    /// we will send an HTTPS POST request to the specified URL, containing a JSON-serialized <see cref="Update">Update</see>. 
    /// In case of an unsuccessful request, we will give up after a reasonable amount of attempts.
    /// If you'd like to make sure that the webhook was set by you, you can specify secret data in the parameter secret_token. 
    /// If specified, the request will contain a header “X-Telegram-Bot-Api-Secret-Token” with the secret token as content.
    /// </summary>
    /// <param name="parameters"></param>
    /// <returns>Returns True on success.</returns>
    public async Task<ResponseAPI<bool>> SetWebhookAsync(SetWebhookParameters parameters)
    {
        if (string.IsNullOrEmpty(parameters.Url))
        {
            throw new ArgumentNullException(nameof(parameters.Url));
        }
        
        return await RequestAsync<bool>("setWebhook", parameters);
    }

    /// <summary>
    /// Use this method to remove webhook integration if you decide to switch back to <see href="https://core.telegram.org/bots/api#getupdates">getUpdates</see>.
    /// </summary>
    /// <param name="parameters"></param>
    /// <returns>Returns True on success.</returns>
    public async Task<ResponseAPI<bool>> DeleteWebhookAsync(DeleteWebhookParameters parameters = null)
    {
        return await RequestAsync<bool>("deleteWebhook", parameters);
    }

    /// <summary>
    /// Use this method to get current webhook status. Requires no parameters.
    /// If the bot is using getUpdates, will return an object with the url field empty.
    /// </summary>
    /// <param name="parameters"></param>
    /// <returns>On success, returns a <see cref="WebhookInfo">WebhookInfo</see> object.</returns>
    public async Task<ResponseAPI<WebhookInfo>> GetWebhookInfoAsync()
    {
        return await RequestAsync<WebhookInfo>("getWebhookInfo");
    }
}
