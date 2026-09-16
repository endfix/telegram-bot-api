using System.Net.Http;

namespace Endfix.Telegram.BotAPI.Tests.Integration;

internal static class TelegramIntegrationHttp
{
    public const int RequestDelayMilliseconds = 500;

    public static HttpClient CreateClient()
        => new(new PacingHandler(new HttpClientHandler()), disposeHandler: true)
        {
            Timeout = TimeSpan.FromSeconds(30)
        };

    private sealed class PacingHandler(HttpMessageHandler inner) : DelegatingHandler(inner)
    {
        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            await Task.Delay(RequestDelayMilliseconds, cancellationToken).ConfigureAwait(false);
            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}
