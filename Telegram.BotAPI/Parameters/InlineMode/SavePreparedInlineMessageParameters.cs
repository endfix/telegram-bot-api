using Telegram.BotAPI.Types;
namespace Telegram.BotAPI.Parameters;

public sealed class SavePreparedInlineMessageParameters : ApiRequestParameters
{
    public long UserId { get; set; }

    public InlineQueryResult Result { get; set; }

    public bool AllowUserChats { get; set; }

    public bool AllowBotChats { get; set; }

    public bool AllowGroupChats { get; set; }

    public bool AllowChannelChats { get; set; }
}
