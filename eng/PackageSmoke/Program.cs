using System.Reflection;
using System.Runtime.Versioning;
using System.Text;
using System.Text.Json;
using Endfix.Telegram.BotAPI;
using Endfix.Telegram.BotAPI.Extensions;
using Endfix.Telegram.BotAPI.Parameters;
using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

var expectedAsset = args.SingleOrDefault()
    ?? throw new InvalidOperationException("Pass the expected package asset as the only argument.");

var expectedFramework = expectedAsset switch
{
    "net8.0" => ".NETCoreApp,Version=v8.0",
    "netstandard2.0" => ".NETStandard,Version=v2.0",
    _ => throw new InvalidOperationException($"Unsupported expected asset: {expectedAsset}.")
};
var expectedJsonMajor = expectedAsset == "net8.0" ? 8 : 10;

var libraryAssembly = typeof(BotApiClient).Assembly;
var actualFramework = libraryAssembly
    .GetCustomAttribute<TargetFrameworkAttribute>()?
    .FrameworkName;
Ensure(
    actualFramework == expectedFramework,
    $"Expected {expectedFramework}, loaded {actualFramework ?? "an assembly without a target framework"}.");

var actualJsonMajor = typeof(JsonSerializer).Assembly.GetName().Version?.Major;
Ensure(
    actualJsonMajor == expectedJsonMajor,
    $"Expected System.Text.Json major {expectedJsonMajor}, loaded {actualJsonMajor?.ToString() ?? "unknown"}.");

const string memberJson =
    "{\"status\":\"member\",\"user\":{\"id\":42,\"is_bot\":false,\"first_name\":\"Smoke\"}}";
Ensure(
    memberJson.Deserialize<ChatMember>() is ChatMemberMember,
    "Polymorphic ChatMember deserialization failed.");

using var handler = new SmokeHandler();
using var httpClient = new HttpClient(handler);
var client = new BotApiClient("smoke-token", httpClient);
var response = await client.RequestAsync<bool>(new ApiRequest(
    "sendPhoto",
    new SendPhotoParameters
    {
        ChatId = 123456789L,
        Photo = new InputPhotoFile(InputFileSource.FromMemory(
            new byte[] { 0x41, 0x42, 0x43 },
            "smoke-photo.jpg"))
    }));

Ensure(response.Ok && response.Result, "The local multipart request did not return a successful result.");
Ensure(handler.SawExpectedMultipart, "The local multipart request did not contain the expected fields.");

client.Dispose();
using var ownershipProbe = await httpClient.GetAsync("https://example.invalid/ownership-probe");
Ensure(ownershipProbe.IsSuccessStatusCode, "BotApiClient disposed the supplied HttpClient.");

Console.WriteLine(
    $"Package smoke passed: asset={expectedAsset}, framework={actualFramework}, System.Text.Json={actualJsonMajor}.");

static void Ensure(bool condition, string message)
{
    if (!condition)
    {
        throw new InvalidOperationException(message);
    }
}

internal sealed class SmokeHandler : HttpMessageHandler
{
    public bool SawExpectedMultipart { get; private set; }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        if (request.Content is MultipartFormDataContent multipart)
        {
            var chatId = multipart.Single(part =>
                Normalize(part.Headers.ContentDisposition?.Name) == "chat_id");
            var photo = multipart.Single(part =>
                Normalize(part.Headers.ContentDisposition?.Name) == "photo");

            SawExpectedMultipart =
                await chatId.ReadAsStringAsync(cancellationToken) == "123456789" &&
                Normalize(photo.Headers.ContentDisposition?.FileName) == "smoke-photo.jpg" &&
                (await photo.ReadAsByteArrayAsync(cancellationToken)).SequenceEqual(
                    new byte[] { 0x41, 0x42, 0x43 });
        }

        return new HttpResponseMessage(System.Net.HttpStatusCode.OK)
        {
            Content = new StringContent(
                "{\"ok\":true,\"result\":true}",
                Encoding.UTF8,
                "application/json")
        };
    }

    private static string? Normalize(string? value)
        => value is { Length: >= 2 } && value[0] == '"' && value[^1] == '"'
            ? value[1..^1]
            : value;
}
