namespace Telegram.BotAPI.Parameters;

public sealed class PinChatMessageParameters : ApiRequestParameters
{
    public string? BusinessConnectionId { get; init; }

    public required object ChatId { get; init; }

    public required int MessageId { get; init; }

    public bool? DisableNotification { get; init; }
}
