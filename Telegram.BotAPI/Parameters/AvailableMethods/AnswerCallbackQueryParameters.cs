using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

public sealed class AnswerCallbackQueryParameters : ApiRequestParameters
{
    public required string CallbackQueryId { get; init; }

    public string? Text { get; init; }

    public bool? ShowAlert { get; init; }

    public string? Url { get; init; }

    public int? CacheTime { get; init; }
}
