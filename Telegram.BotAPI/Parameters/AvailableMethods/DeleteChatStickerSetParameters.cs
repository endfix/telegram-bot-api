using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class DeleteChatStickerSetParameters : ApiRequestParameters
{
    public required ChatIdSource ChatId { get; init; }
}
