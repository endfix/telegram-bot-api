using Telegram.BotAPI.Protocol;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class SendDiceParameters : ApiRequestParameters
{
    public string? BusinessConnectionId { get; init; }

    public required ChatIdSource ChatId { get; init; }

    public int? MessageThreadId { get; init; }

    public int? DirectMessagesTopicId { get; init; }

    public string? Emoji { get; init; }

    public bool? DisableNotification { get; init; }

    public bool? ProtectContent { get; init; }

    public bool? AllowPaidBroadcast { get; init; }

    public string? MessageEffectId { get; init; }

    public SuggestedPostParameters? SuggestedPostParameters { get; init; }

    public ReplyParameters? ReplyParameters { get; init; }

    public ReplyMarkup? ReplyMarkup { get; init; }
}
