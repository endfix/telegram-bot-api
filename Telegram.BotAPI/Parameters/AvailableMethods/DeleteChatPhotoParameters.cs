using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>deleteChatPhoto</c> method.
/// </summary>
public sealed class DeleteChatPhotoParameters : ApiRequestParameters
{
    public required ChatIdSource ChatId { get; init; }
}
