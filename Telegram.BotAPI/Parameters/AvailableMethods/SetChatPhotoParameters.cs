using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class SetChatPhotoParameters : ApiRequestParameters
{
    public object ChatId { set; get; }

    public InputFile Photo { set; get; }
}
