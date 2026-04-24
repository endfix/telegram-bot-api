using System.Collections.Generic;
using Telegram.BotAPI.Protocol;

namespace Telegram.BotAPI.Parameters;

public sealed class GetCustomEmojiStickersParameters : ApiRequestParameters
{
    public required IReadOnlyList<string> CustomEmojiIds { get; init; }
}
