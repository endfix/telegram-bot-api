using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class SetChatPhotoParameters : ApiRequestParameters
{
    public required object ChatId { get; init; }

    public required InputFile Photo { get; init; }
}
