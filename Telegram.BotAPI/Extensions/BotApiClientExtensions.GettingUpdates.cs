using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Endfix.Telegram.BotAPI.Enums;
using Endfix.Telegram.BotAPI.Parameters;
using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Extensions;

public static partial class BotApiClientExtensions
{
    internal static async Task<IReadOnlyList<Update>?> GetUpdatesAsync(
        this IBotApiClient client, 
        GetUpdatesParameters? parameters = null, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<IReadOnlyList<Update>>(new ApiRequest("getUpdates", parameters), cancellationToken);

    /// <summary>
    /// Retrieves pending updates using long polling.
    /// </summary>
    /// <param name="client">The Bot API client.</param>
    /// <param name="offset">Identifier of the first update to return.</param>
    /// <param name="limit">Maximum number of updates to return.</param>
    /// <param name="timeout">Long-polling timeout in seconds.</param>
    /// <param name="AllowedUpdates">Optional update types to receive.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    public static async Task<IReadOnlyList<Update>?> GetUpdatesAsync(
        this IBotApiClient client,
        long? offset = null,
        int? limit = null,
        int? timeout = null,
        IReadOnlyList<UpdateType>? AllowedUpdates = null,
        CancellationToken cancellationToken = default)
        => await client.GetUpdatesAsync(new GetUpdatesParameters
        {
            Offset = offset,
            Limit = limit,
            Timeout = timeout,
            AllowedUpdates = AllowedUpdates
        }, cancellationToken);

    internal static async Task<bool> SetWebhookAsync(
        this IBotApiClient client, 
        SetWebhookParameters parameters, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("setWebhook", parameters), cancellationToken);

    /// <summary>
    /// Configures a webhook for receiving updates.
    /// </summary>
    /// <param name="client">The Bot API client.</param>
    /// <param name="url">HTTPS URL where Telegram should send updates.</param>
    /// <param name="certificate">Optional public certificate for self-signed HTTPS.</param>
    /// <param name="ipAddress">Optional fixed IP address for the webhook.</param>
    /// <param name="maxConnections">Maximum number of simultaneous HTTPS connections.</param>
    /// <param name="allowedUpdates">Optional update types to receive.</param>
    /// <param name="dropPendingUpdates">Whether to discard pending updates.</param>
    /// <param name="secretToken">Optional secret token sent in the webhook header.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    public static async Task<bool> SetWebhookAsync(
        this IBotApiClient client,
        string url,
        InputFile? certificate = null,
        string? ipAddress = null,
        int? maxConnections = null,
        IReadOnlyList<UpdateType>? allowedUpdates = null,
        bool? dropPendingUpdates = null,
        string? secretToken = null,
        CancellationToken cancellationToken = default)
        => await client.SetWebhookAsync(new SetWebhookParameters
        { 
            Url = url,
            Certificate = certificate,
            IpAddress = ipAddress,
            MaxConnections = maxConnections,
            AllowedUpdates = allowedUpdates,
            DropPendingUpdates = dropPendingUpdates,
            SecretToken = secretToken
        }, cancellationToken);

    internal static async Task<bool> DeleteWebhookAsync(
        this IBotApiClient client, 
        DeleteWebhookParameters? parameters = null, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<bool>(new ApiRequest("deleteWebhook", parameters), cancellationToken);

    /// <summary>
    /// Removes the current webhook and optionally discards pending updates.
    /// </summary>
    /// <param name="client">The Bot API client.</param>
    /// <param name="dropPendingUpdates">Whether to discard pending updates.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    public static async Task<bool> DeleteWebhookAsync(
        this IBotApiClient client,
        bool? dropPendingUpdates = null,
        CancellationToken cancellationToken = default)
        => await client.DeleteWebhookAsync(new DeleteWebhookParameters
        {
            DropPendingUpdates = dropPendingUpdates
        }, cancellationToken);

    internal static async Task<WebhookInfo> GetWebhookInfoAsync(
        this IBotApiClient client, 
        GetWebhookInfoParameters? parameters = null, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<WebhookInfo>(new ApiRequest("getWebhookInfo", parameters), cancellationToken);

    /// <summary>
    /// Retrieves the current webhook configuration.
    /// </summary>
    /// <param name="client">The Bot API client.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    public static async Task<WebhookInfo> GetWebhookInfoAsync(
        this IBotApiClient client, 
        CancellationToken cancellationToken = default)
        => await client.GetWebhookInfoAsync(new GetWebhookInfoParameters
        {
            // No parameters to set for GetWebhookInfo
        }, cancellationToken);
}
