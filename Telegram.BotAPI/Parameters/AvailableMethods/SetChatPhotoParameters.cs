using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class SetChatPhotoParameters : ApiRequestParameters
{
    public required ChatIdSource ChatId { get; init; }

    public required InputPhotoFile Photo { get; init; }
}
