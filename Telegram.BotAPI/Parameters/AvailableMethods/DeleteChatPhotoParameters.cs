using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class DeleteChatPhotoParameters : ApiRequestParameters
{
    public required ChatIdSource ChatId { get; init; }
}
