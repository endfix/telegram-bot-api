using System.Collections.Generic;

namespace Telegram.BotAPI.Parameters;

public sealed class SetStickerKeywordsParameters : ApiRequestParameters
{
    public required string Sticker { get; init; }

    public IReadOnlyList<string>? Keywords { get; init; }
}
