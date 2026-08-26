using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

public sealed class SetGameScoreParameters : ApiRequestParameters
{
    public required long UserId { get; init; }

    public required int Score { get; init; }

    public bool? Force { get; init; }

    public bool? DisableEditMessage { get; init; }

    public long? ChatId { get; init; }

    public long? MessageId { get; init; }

    public string? InlineMessageId { get; init; }
}
