using Telegram.BotAPI.Protocol;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class SendGameParameters : ApiRequestParameters
{
    public string? BusinessConnectionId { get; init; }

    public required long ChatId { get; init; }

    public int? MessageThreadId { get; init; }

    public required string GameShortName { get; init; }

    public bool? DisableNotification { get; init; }

    public bool? ProtectContent { get; init; }

    public bool? AllowPaidBroadcast { get; init; }

    public string? MessageEffectId { get; init; }

    public ReplyParameters? ReplyParameters { get; init; }

    public InlineKeyboardMarkup? ReplyMarkup { get; init; }
}
