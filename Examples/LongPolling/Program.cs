using Telegram.BotAPI.Enums;
using Telegram.BotAPI.Extensions;

namespace Telegram.BotAPI.Example.LongPolling;

internal class Program
{
    static async Task Main(string[] args)
    {
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

            var api = new BotApiClient("123456:ABC-DEF1234ghIkl-zyx57W2v1u123ew11", client);

            await api.DeleteWebhookAsync(new() { DropPendingUpdates = true });

            api.OnUpdate += (client, update) =>
            {
                try
                {
                    Console.WriteLine($"Update({update.Type}): {update.Serialize(writeIndented: true)}");

                    switch (update.Type)
                    {
                        case UpdateType.Message:
                            {
                                _ = Task.Run(async () =>
                                {
                                    // echo (ping - pong)
                                    var result = await api.SendMessageAsync(new()
                                    {
                                        ChatId = update.Message!.Chat.Id,
                                        Text = update.Message?.Text ?? string.Empty,
                                    });
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

            _ = api.StartPollingAsync(new() { Limit = 10 });
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
