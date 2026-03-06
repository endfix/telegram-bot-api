namespace Telegram.BotAPI.Parameters;

public sealed class ExportChatInviteLinkParameters : ApiRequestParameters
{
    public required object ChatId { get; init; }
}
