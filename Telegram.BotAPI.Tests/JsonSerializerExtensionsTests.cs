using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Endfix.Telegram.BotAPI.Extensions;
using FluentAssertions;
using Xunit;

namespace Endfix.Telegram.BotAPI.Tests;

public class JsonSerializerExtensionsTests
{
    [Fact]
    public void SharedOptions_AreReadOnlyBeforeSerialization()
    {
        JsonSerializerExtensions.Options.IsReadOnly.Should().BeTrue();
        JsonSerializerExtensions.IndentedOptions.IsReadOnly.Should().BeTrue();

        var changeOptions = () => JsonSerializerExtensions.Options.PropertyNamingPolicy = null;
        var changeIndentedOptions = () => JsonSerializerExtensions.IndentedOptions.WriteIndented = false;

        changeOptions.Should().Throw<InvalidOperationException>();
        changeIndentedOptions.Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public void SharedOptions_CanBeCopiedForIndependentCustomization()
    {
        var options = new JsonSerializerOptions(JsonSerializerExtensions.Options)
        {
            PropertyNamingPolicy = null
        };

        options.IsReadOnly.Should().BeFalse();
        options.PropertyNamingPolicy.Should().BeNull();
        JsonSerializerExtensions.Options.PropertyNamingPolicy.Should().Be(JsonNamingPolicy.SnakeCaseLower);
    }

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

    [Fact]
    public void TryGetEnum_ReturnsFalseForMalformedEnumValue()
    {
        using var document = JsonDocument.Parse("\"not-a-value\"");
        var options = new JsonSerializerOptions();
        options.Converters.Add(new JsonStringEnumConverter());

        var success = document.RootElement.TryGetEnum<TestEnum>(options, out var value);

        success.Should().BeFalse();
        value.Should().Be(default(TestEnum));
    }

    [Fact]
    public void TryGetEnum_DoesNotHideUnexpectedConverterFailure()
    {
        using var document = JsonDocument.Parse("\"value\"");
        var options = new JsonSerializerOptions();
        options.Converters.Add(new ThrowingEnumConverter());

        var action = () => document.RootElement.TryGetEnum<TestEnum>(options, out _);

        action.Should().Throw<InvalidOperationException>()
            .WithMessage("Unexpected converter failure.");
    }

    public sealed class TestPayload
    {
        public string DisplayName { get; set; } = string.Empty;

        public int[] Values { get; set; } = [];
    }

    private enum TestEnum
    {
        Value
    }

    private sealed class ThrowingEnumConverter : JsonConverter<TestEnum>
    {
        public override TestEnum Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
            => throw new InvalidOperationException("Unexpected converter failure.");

        public override void Write(
            Utf8JsonWriter writer,
            TestEnum value,
            JsonSerializerOptions options)
            => throw new NotSupportedException();
    }
}
