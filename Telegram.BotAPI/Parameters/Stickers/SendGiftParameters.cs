using System.Collections.Generic;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class SendGiftParameters : ApiRequestParameters
{
    public long? UserId { get; init; }

    public object? ChatId { get; init; }

    public required string GiftId { get; init; }

    public bool? PayForUpgrade { get; init; }

    public string? Text { get; init; }

    public string? TextParseMode { get; init; }

    public IReadOnlyList<MessageEntity>? TextEntities { get; init; }
}
