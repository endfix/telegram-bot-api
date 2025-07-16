using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class PostStoryParameters : ApiRequestParameters
{
    public string BusinessConnectionId { get; set; }

    public InputStoryContent Content { get; set; }

    public int ActivePeriod { get; set; }

    public string Caption { get; set; }

    public string ParseMode { get; set; }

    public MessageEntity[] CaptionEntities { get; set; }

    public StoryArea[] Areas { get; set; }

    public bool PostToChatPage { get; set; }

    public bool ProtectContent { get; set; }
}
