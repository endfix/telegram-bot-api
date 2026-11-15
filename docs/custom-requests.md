# Custom requests

The typed helpers cover the Bot API methods exposed by the package. For a method
or parameter shape that is not wrapped yet, derive from `ApiRequestParameters`
and send it through `RequestAsync` or `ExecuteAsync`:

```cs
using Endfix.Telegram.BotAPI.Enums;
using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

public sealed class CustomSendMessageParameters : ApiRequestParameters
{
    public required ChatIdSource ChatId { get; init; }
    public required string Text { get; init; }
    public ParseMode? ParseMode { get; init; }
}

var response = await api.RequestAsync<Message>(new ApiRequest(
    "sendMessage",
    new CustomSendMessageParameters
    {
        ChatId = 123456789L,
        Text = "Hello from custom parameters",
        ParseMode = ParseMode.HTML
    }));

if (!response.Ok)
{
    Console.WriteLine($"{response.ErrorCode}: {response.Description}");
}
```

Properties use the same snake-case policy and converters as the built-in
parameter types: `ChatId` becomes `chat_id`, null values are omitted, and
`[JsonPropertyName]` is not required. Use `ExecuteAsync` instead of
`RequestAsync` when an unsuccessful response should throw
`ApiRequestException`.

An `InputFile` or `IFileSource` anywhere in the parameter object graph switches
the request to `multipart/form-data`. A top-level file property is attached
under its field name; nested files inside objects or arrays are replaced with
`attach://` references automatically:

```cs
public sealed class CustomSendPhotoParameters : ApiRequestParameters
{
    public required ChatIdSource ChatId { get; init; }
    public required PhotoSource Photo { get; init; }
    public string? Caption { get; init; }
}

await api.ExecuteAsync<Message>(new ApiRequest(
    "sendPhoto",
    new CustomSendPhotoParameters
    {
        ChatId = 123456789L,
        Photo = new InputPhotoFile("photo.jpg"),
        Caption = "Custom upload"
    }));
```

The method name passed to `ApiRequest` must start with an ASCII letter and
contain only ASCII letters, digits, and underscores. `required` members need
C# 11 or later and `init` accessors need C# 9; use ordinary `get`/`set`
accessors on older compilers.
