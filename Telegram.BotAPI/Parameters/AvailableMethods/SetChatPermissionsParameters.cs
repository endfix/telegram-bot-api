using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class SetChatPermissionsParameters : ApiRequestParameters
{
    public object ChatId { get; set; }

    public ChatPermissions Permissions { get; set; }

    public bool UseIndependentChatPermissions { get; set; }
}
