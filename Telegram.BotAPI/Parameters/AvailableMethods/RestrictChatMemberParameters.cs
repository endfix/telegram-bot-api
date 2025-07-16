using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class RestrictChatMemberParameters : ApiRequestParameters
{
    public object ChatId { get; set; }

    public long UserId { get; set; }

    public ChatPermissions Permissions { get; set; }

    public bool UseIndependentChatPermissions { get; set; }

    public int UntilDate { get; set; }
}
