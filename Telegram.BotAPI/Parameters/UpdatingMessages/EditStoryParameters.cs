using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class EditStoryParameters : ApiRequestParameters
{
    public string BusinessConnectionId { get; set; }

    public int StoryId { get; set; }

    public InputStoryContent Content { get; set; }

    public string Caption { get; set; }

    public string ParseMode { get; set; }

    public MessageEntity[] CaptionEntities { get; set; }

    public StoryArea Areas { get; set; }
}
