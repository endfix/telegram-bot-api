using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>deleteChatStickerSet</c> method.
/// </summary>
public sealed class DeleteChatStickerSetParameters : ApiRequestParameters
{
    public required ChatIdSource ChatId { get; init; }
}
