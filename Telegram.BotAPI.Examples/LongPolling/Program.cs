using Microsoft.Extensions.Configuration;
using Endfix.Telegram.BotAPI.Enums;
using Endfix.Telegram.BotAPI.Extensions;

namespace Endfix.Telegram.BotAPI.Example.LongPolling;

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

            var api = new BotApiClient(token: token, client);

            await api.DeleteWebhookAsync(dropPendingUpdates: true);

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
                                var result = await api.SendMessageAsync(chatId: update.Message!.Chat.Id, text: text);

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

            await api.StartPollingAsync(limit: 10, cancellationToken: cts.Token);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }
}
