using System.Collections.Generic;

namespace Telegram.BotAPI.Types;

// https://core.telegram.org/bots/api#inputpolloption
public sealed class InputPollOption
{
    public string Text { get; set; }

    public string TextParseMode { get; set; }

    public List<MessageEntity> TextEntities { get; set; }
}
