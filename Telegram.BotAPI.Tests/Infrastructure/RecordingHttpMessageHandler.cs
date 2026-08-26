using System.Net;
using System.Text;

namespace Endfix.Telegram.BotAPI.Tests.Infrastructure;

internal sealed class RecordingHttpMessageHandler : HttpMessageHandler
{
    public RecordedRequest? LastRequest { get; private set; }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        LastRequest = await RecordedRequest.CreateAsync(request, cancellationToken);

        return new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent(
                """{"ok":true,"result":true}""",
                Encoding.UTF8,
                "application/json")
        };
    }
}

internal sealed record RecordedRequest(
    HttpMethod Method,
    Uri? Uri,
    string? ContentType,
    IReadOnlyList<RecordedPart> Parts)
{
    public static async Task<RecordedRequest> CreateAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var parts = new List<RecordedPart>();

        if (request.Content is MultipartFormDataContent multipart)
        {
            foreach (var content in multipart)
            {
                parts.Add(new RecordedPart(
                    NormalizeHeaderValue(content.Headers.ContentDisposition?.Name),
                    NormalizeHeaderValue(content.Headers.ContentDisposition?.FileName),
                    content.Headers.ContentType?.MediaType,
                    await content.ReadAsByteArrayAsync(cancellationToken)));
            }
        }

        return new RecordedRequest(
            request.Method,
            request.RequestUri,
            request.Content?.Headers.ContentType?.MediaType,
            parts);
    }

    private static string? NormalizeHeaderValue(string? value)
    {
        if (value is not { Length: >= 2 } || value[0] != '"' || value[^1] != '"')
        {
            return value;
        }

        return value[1..^1].Replace("\\\"", "\"");
    }
}

internal sealed record RecordedPart(
    string? Name,
    string? FileName,
    string? ContentType,
    byte[] Content)
{
    public string Text => Encoding.UTF8.GetString(Content);
}
