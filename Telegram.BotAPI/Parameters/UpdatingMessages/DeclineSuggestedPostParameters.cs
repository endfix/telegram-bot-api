using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

public sealed class DeclineSuggestedPostParameters : ApiRequestParameters
{
    public required long ChatId { get; init; }

    public required long MessageId { get; init; }

    public string? Comment { get; init; }
}
