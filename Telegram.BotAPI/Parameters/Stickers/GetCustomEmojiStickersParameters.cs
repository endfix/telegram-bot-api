using System.Collections.Generic;

namespace Telegram.BotAPI.Parameters;

public sealed class GetCustomEmojiStickersParameters : ApiRequestParameters
{
    public required IReadOnlyList<string> CustomEmojiIds { get; init; }
}
