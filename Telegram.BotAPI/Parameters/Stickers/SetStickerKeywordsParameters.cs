using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

public sealed class SetStickerKeywordsParameters : ApiRequestParameters
{
    public required string Sticker { get; init; }

    public IReadOnlyList<string>? Keywords { get; init; }
}
