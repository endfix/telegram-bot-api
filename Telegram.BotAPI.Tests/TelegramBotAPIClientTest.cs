using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Telegram.BotAPI.Tests
{
    public class TelegramBotAPIClientTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public TelegramBotAPIClientTest(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("7549431617:AAGf28x4qz97F6z1VAH0P9pOzluWS2J_G-o")] // Telegram Bot API Test
        public async Task LongPolling(string token)
        {
            var api = new Client
            {
                Token = token
            };

            var lastUpdateId = 0;

            for (var i = 0; i < 10; i++)
            {
                var response = await api.GetUpdatesAsync(offset: lastUpdateId);

                Assert.True(response.Ok, response.Description);
                if (response.Ok)
                {
                    foreach (var update in response.Result)
                    {
                        Assert.Equal(lastUpdateId, update.UpdateId);
                        
                        lastUpdateId = update.UpdateId + 1;
                    }
                }
            }         
        }

        /*[Theory]
        [InlineData("/webhook")]
        public async Task Webhook(string url)
        {
            using var client = _factory.CreateClient();

            var content = JsonContent.Create(new Update());
            var response = await client.PostAsync(url, content);

            var responseContentType = response.Content.Headers.ContentType;

            Assert.NotNull(responseContentType);
            if (response is not null)
            {
                Assert.Equal("application/json; charset=utf-8", responseContentType.ToString());
            }

            var json = await response.Content.ReadAsStringAsync();

            Assert.NotNull(json);
            if (json is not null)
            {
                //Assert.Fail("json: " + json);

                var update = System.Text.Json.JsonSerializer.Deserialize<Update>(json);
                //Assert.IsType<Task<Update>>(update);

                Assert.Fail("updateId: " + update.UpdateId);

                Assert.Equal(123, update.UpdateId);
            }
        }

        [Theory]
        [InlineData("[REDACTED_TELEGRAM_BOT_TOKEN]", "989722390")]
        [InlineData("[REDACTED_TELEGRAM_BOT_TOKEN]", "6952838336")]
        public async void SendMessageAsync(string token, string userId)
        {
            var api = new TelegramBotAPIClient
            {
                Token = token
            };

            var response = await api.SendMessageAsync(userId, "Hi!");

            Assert.True(response.Ok, response.Description);
        }*/
    }
}
