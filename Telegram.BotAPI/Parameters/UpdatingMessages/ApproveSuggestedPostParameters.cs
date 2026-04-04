namespace Telegram.BotAPI.Parameters;

public sealed class ApproveSuggestedPostParameters : ApiRequestParameters
{
    public required long ChatId { get; init; }

    public required long MessageId { get; init; }

    public int? SendDate { get; init; }
}
