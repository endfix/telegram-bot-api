using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class SetMessageReactionParameters : ApiRequestParameters
{
    public object ChatId { get; set; }

    public int MessageId { get; set; }

    public ReactionType[] Reaction { get; set; }

    public bool IsBig { get; set; }
}
