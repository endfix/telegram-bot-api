using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

public sealed class SetChatStickerSetParameters : ApiRequestParameters
{
    public required ChatIdSource ChatId { get; init; }

    public required string StickerSetName { get; init; }
}
