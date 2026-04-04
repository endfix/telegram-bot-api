using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class SetChatStickerSetParameters : ApiRequestParameters
{
    public required ChatIdSource ChatId { get; init; }

    public required string StickerSetName { get; init; }
}
