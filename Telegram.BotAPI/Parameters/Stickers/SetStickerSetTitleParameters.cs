using Endfix.Telegram.BotAPI.Protocol;

namespace Endfix.Telegram.BotAPI.Parameters;

public sealed class SetStickerSetTitleParameters : ApiRequestParameters
{
    public required string Name { get; init; }

    public required string Title { get; init; }
}
