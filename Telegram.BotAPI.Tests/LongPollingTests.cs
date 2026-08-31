using Xunit;
using Endfix.Telegram.BotAPI.Extensions;
using Endfix.Telegram.BotAPI.Enums;

namespace Endfix.Telegram.BotAPI.Tests;

public class LongPollingTests
{
    [Fact]
    public async Task AwaitMessage()
    {
        var token = Environment.GetEnvironmentVariable("TELEGRAM_BOTAPI_TEST_TOKEN");
        if (string.IsNullOrWhiteSpace(token))
        {
            return;
        }

        var api = CreateApi(token);
        using var cts = new CancellationTokenSource(TimeSpan.FromMinutes(1));

        await api.DeleteWebhookAsync(dropPendingUpdates: true, cancellationToken: cts.Token);

        api.OnUpdate += async (client, update) =>
        {
            try
            {
                if (update.Type == UpdateType.Message)
                {
                    // echo (ping - pong)
                    var result = await api.SendMessageAsync(
                        chatId: update.Message!.Chat.Id,
                        text: update.Message?.Text ?? "No text");

                    cts.Cancel();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error processing update: " + e.ToString());
            }
        };

        await api.StartPollingAsync(limit: 10, cancellationToken: cts.Token);
    }

    private static BotApiClient CreateApi(string token)
    {
        var handler = new SocketsHttpHandler
        {
            PooledConnectionLifetime = TimeSpan.FromSeconds(5),
            MaxConnectionsPerServer = 10
        };

        var client = new HttpClient(handler)
        {
            Timeout = TimeSpan.FromMinutes(5)
        };

        return new BotApiClient(
            token: token,
            httpClient: client,
            maxRetryAttempts: 3);
    }
}
