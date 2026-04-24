using Telegram.BotAPI.Protocol;
using Telegram.BotAPI.Types;
namespace Telegram.BotAPI.Parameters;

public sealed class SavePreparedInlineMessageParameters : ApiRequestParameters
{
    public required long UserId { get; init; }

    public required InlineQueryResult Result { get; init; }

    public bool? AllowUserChats { get; init; }

    public bool? AllowBotChats { get; init; }

    public bool? AllowGroupChats { get; init; }

    public bool? AllowChannelChats { get; init; }
}
