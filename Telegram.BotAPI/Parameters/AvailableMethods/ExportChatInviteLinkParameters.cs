using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class ExportChatInviteLinkParameters : ApiRequestParameters
{
    public required ChatIdSource ChatId { get; init; }
}
