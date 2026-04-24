using System.Collections.Generic;
using Telegram.BotAPI.Protocol;

namespace Telegram.BotAPI.Parameters;

public sealed class SetStickerKeywordsParameters : ApiRequestParameters
{
    public required string Sticker { get; init; }

    public IReadOnlyList<string>? Keywords { get; init; }
}
