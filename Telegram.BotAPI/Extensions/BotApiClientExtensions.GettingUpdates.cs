using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Telegram.BotAPI.Enums;
using Telegram.BotAPI.Parameters;
using Telegram.BotAPI.Protocol;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Extensions;

public static partial class BotApiClientExtensions
{
    internal static async Task<IReadOnlyList<Update>?> GetUpdatesAsync(
        this IBotApiClient client, 
        GetUpdatesParameters? parameters = null, 
        CancellationToken cancellationToken = default)
        => await client.ExecuteAsync<IReadOnlyList<Update>>(new ApiRequest("getUpdates", parameters), cancellationToken);

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

    public static async Task<WebhookInfo> GetWebhookInfoAsync(
        this IBotApiClient client, 
        CancellationToken cancellationToken = default)
        => await client.GetWebhookInfoAsync(new GetWebhookInfoParameters
        {
            // No parameters to set for GetWebhookInfo
        }, cancellationToken);
}
