using Xunit;
using Telegram.BotAPI.Extensions;
using Telegram.BotAPI.Enums;
using Telegram.BotAPI.Parameters;

namespace Telegram.BotAPI.Tests;

public class LongPollingTests
{
    private readonly BotApiClient _api;

    public LongPollingTests()
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

        _api = new BotApiClient(
            token: "[REDACTED_TELEGRAM_BOT_TOKEN]",
            httpClient: client,
            retryDelays: [ 10, 30, 60 ]);
    }

    [Fact]
    public async Task AwaitMessage()
    {
        using var cts = new CancellationTokenSource();

        await _api.DeleteWebhookAsync(new() { DropPendingUpdates = true });

        _api.OnUpdate += async (client, update) =>
        {
            try
            {
                if (update.Type == UpdateType.Message)
                {
                    // echo (ping - pong)
                    var result = await _api.SendMessageAsync(new()
                    {
                        ChatId = update.Message!.Chat.Id,
                        Text = update.Message?.Text ?? "No text",
                    });

                    cts.Cancel();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error processing update: " + e.ToString());
            }
        };

        await _api.StartPollingAsync(parameters: new GetUpdatesParameters() { Limit = 10 }, cancellationToken: cts.Token);
    }
}
