using Microsoft.AspNetCore.Builder;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using Telegram.BotAPI.Structs;

namespace Telegram.BotAPI.Tests
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            /*var builder = WebApplication.CreateBuilder(args);

            var app = builder.Build();

            app.MapPost("/webhook", () => new Update
            {
                UpdateId = 228
            });
            app.Run();*/

            /*var api = new TelegramBotAPIClient
            {
                Token = "[REDACTED_TELEGRAM_BOT_TOKEN]"
            };

            var response = await api.GetUpdatesAsync();

            //Console.WriteLine("response: " + response.Result[0]);
            Console.WriteLine("response: " + response.Serialize());*/
        }
    }
}
