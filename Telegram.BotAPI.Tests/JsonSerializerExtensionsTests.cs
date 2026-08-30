using System.Text;
using Endfix.Telegram.BotAPI.Extensions;
using FluentAssertions;
using Xunit;

namespace Endfix.Telegram.BotAPI.Tests;

public class JsonSerializerExtensionsTests
{
    [Fact]
    public async Task DeserializeAsyncFromStream_RestoresValueAndLeavesStreamOpen()
    {
        const string json = """{"display_name":"Endfix","values":[1,2,3]}""";
        using var stream = new MemoryStream(Encoding.UTF8.GetBytes(json));

        var actual = await stream.DeserializeAsync<TestPayload>();

        actual.Should().BeEquivalentTo(new TestPayload
        {
            DisplayName = "Endfix",
            Values = [1, 2, 3]
        });
        stream.CanRead.Should().BeTrue();
    }

    public sealed class TestPayload
    {
        public string DisplayName { get; set; } = string.Empty;

        public int[] Values { get; set; } = [];
    }
}
