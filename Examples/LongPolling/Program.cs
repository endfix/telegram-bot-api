using Microsoft.Extensions.Configuration;
using Telegram.BotAPI.Enums;
using Telegram.BotAPI.Extensions;

namespace Telegram.BotAPI.Example.LongPolling;

internal class Program
{
    static async Task Main(string[] args)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        var token = config.GetSection("TelegramBotApi:Token").Value 
            ?? throw new InvalidOperationException("Telegram bot token is not configured.");

        using var cts = new CancellationTokenSource();

        try
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

            IBotApiClient api = new BotApiClient(token: token, client);

            await api.DeleteWebhookAsync(new() { DropPendingUpdates = true });

            api.OnUpdate += async (client, update) =>
            {
                try
                {
                    Console.WriteLine($"Update({update.Type}): {update.Serialize(writeIndented: true)}");

                    switch (update.Type)
                    {
                        case UpdateType.Message:
                            {
                                var text = update.Message?.Text ?? "No text";

                                if (text.Equals("bye", StringComparison.InvariantCultureIgnoreCase))
                                {
                                    cts.Cancel();
                                    break;
                                }
                                
                                // echo (ping - pong)
                                var result = await api.SendMessageAsync(new()
                                {
                                    ChatId = update.Message!.Chat.Id,
                                    Text = text,
                                });

                                break;
                            }

                        default:
                            {
                                break;
                            }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error processing update: " + e.ToString());
                }
            };

            await api.StartPollingAsync(parameters: new() { Limit = 10 }, cancellationToken: cts.Token);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }
}
