using System.Net;
using System.Net.Http;
using System.Text;
using FluentAssertions;
using Endfix.Telegram.BotAPI;
using Endfix.Telegram.BotAPI.Extensions;
using Endfix.Telegram.BotAPI.Types;
using Xunit;

namespace Endfix.Telegram.BotAPI.Tests;

public sealed class EditMessageResultTests
{
    private const string InlineTrue = """{"ok":true,"result":true}""";
    private const string EditedMessage = """{"ok":true,"result":{"message_id":42,"date":1,"chat":{"id":1,"type":"private"},"text":"Hello"}}""";

    [Fact]
    public async Task EditMessageTextForMessage_DeserializesEditedMessage()
    {
        using var context = new ClientContext(EditedMessage);

        var result = await context.Client.EditMessageTextForMessageAsync(1, 42, "Hello");

        result.MessageId.Should().Be(42);
        result.Text.Should().Be("Hello");
    }

    [Fact]
    public async Task EditMessageTextForInlineMessage_DeserializesTelegramTrue()
    {
        using var context = new ClientContext(InlineTrue);

        var result = await context.Client.EditMessageTextForInlineMessageAsync("inline-id", "Hello");

        result.Should().BeTrue();
    }

    [Fact]
    public async Task EditMessageCaptionForInlineMessage_DeserializesTelegramTrue()
    {
        using var context = new ClientContext(InlineTrue);

        (await context.Client.EditMessageCaptionForInlineMessageAsync("inline-id", "Caption"))
            .Should().BeTrue();
    }

    [Fact]
    public async Task EditMessageMediaForInlineMessage_DeserializesTelegramTrue()
    {
        using var context = new ClientContext(InlineTrue);

        (await context.Client.EditMessageMediaForInlineMessageAsync(
            "inline-id",
            new InputMediaPhoto { Media = "photo-file-id" }))
            .Should().BeTrue();
    }

    [Fact]
    public async Task EditMessageLiveLocationForInlineMessage_DeserializesTelegramTrue()
    {
        using var context = new ClientContext(InlineTrue);

        (await context.Client.EditMessageLiveLocationForInlineMessageAsync("inline-id", 55.75, 37.62))
            .Should().BeTrue();
    }

    [Fact]
    public async Task StopMessageLiveLocationForInlineMessage_DeserializesTelegramTrue()
    {
        using var context = new ClientContext(InlineTrue);

        (await context.Client.StopMessageLiveLocationForInlineMessageAsync("inline-id"))
            .Should().BeTrue();
    }

    [Fact]
    public async Task EditMessageReplyMarkupForInlineMessage_DeserializesTelegramTrue()
    {
        using var context = new ClientContext(InlineTrue);

        (await context.Client.EditMessageReplyMarkupForInlineMessageAsync("inline-id"))
            .Should().BeTrue();
    }

    [Fact]
    public async Task EditMessageTextForMessage_ThrowsWhenTelegramReturnsTrue()
    {
        using var context = new ClientContext(InlineTrue);

        var action = () => context.Client.EditMessageTextForMessageAsync(1, 42, "Hello");

        await action.Should().ThrowAsync<System.Text.Json.JsonException>();
    }

    private sealed class ClientContext : IDisposable
    {
        private readonly HttpClient _httpClient;

        public ClientContext(string responseJson)
        {
            _httpClient = new HttpClient(new StaticHandler(responseJson));
            Client = new BotApiClient("test-token", _httpClient);
        }

        public BotApiClient Client { get; }

        public void Dispose() => _httpClient.Dispose();
    }

    private sealed class StaticHandler(string responseJson) : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
            => Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(responseJson, Encoding.UTF8, "application/json")
            });
    }
}
