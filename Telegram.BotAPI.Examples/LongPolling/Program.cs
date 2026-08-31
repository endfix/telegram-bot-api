using Microsoft.Extensions.Configuration;
using Endfix.Telegram.BotAPI.Enums;
using Endfix.Telegram.BotAPI.Exceptions;
using Endfix.Telegram.BotAPI.Extensions;

namespace Endfix.Telegram.BotAPI.Example.LongPolling;

internal class Program
{
    static async Task Main(string[] args)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddUserSecrets<Program>(optional: true)
            .Build();

        var token = GetToken(config);

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
                        case UpdateType.Message when update.Message?.Text is { Length: > 0 } text:
                            {
                                if (text.Equals("bye", StringComparison.InvariantCultureIgnoreCase))
                                {
                                    cts.Cancel();
                                    break;
                                }
                                
                                // echo (ping - pong)
                                var result = await api.SendMessageAsync(chatId: update.Message!.Chat.Id, text: text);

                                break;
                            }

                        case UpdateType.MyChatMember:
                            Console.WriteLine("The bot's membership status changed.");
                            break;

                        default:
                            {
                                break;
                        }
                    }
                }
                catch (ApiRequestException e)
                {
                    Console.WriteLine($"Telegram API rejected update {update.UpdateId}: {e.ErrorCode} {e.Message}");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error processing update: " + e.ToString());
                }
            };

            await api.StartPollingAsync(limit: 10, maxParallel: 1, cancellationToken: cts.Token);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }

    private static string GetToken(IConfiguration config)
    {
        var token = Environment.GetEnvironmentVariable("TELEGRAM_BOT_TOKEN")
            ?? config["TELEGRAM_BOT_TOKEN"]
            ?? config["TelegramBotApi:Token"];

        return string.IsNullOrWhiteSpace(token) || token == "<bot-token>"
            ? throw new InvalidOperationException("Set TELEGRAM_BOT_TOKEN using environment variables or .NET User Secrets.")
            : token;
    }
}
