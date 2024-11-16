using System.Collections.Generic;

namespace Telegram.BotAPI.Types.AvailableTypes;

public sealed class PollOption
{
    public string Text { get; set; }

    public List<MessageEntity> TextEntities { get; set; }

    public int VoterCount { get; set; }
}
