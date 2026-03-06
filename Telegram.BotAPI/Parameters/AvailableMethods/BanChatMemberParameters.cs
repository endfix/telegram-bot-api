namespace Telegram.BotAPI.Parameters;

public sealed class BanChatMemberParameters : ApiRequestParameters
{
    public required object ChatId { get; init; }

    public required long UserId { get; init; }

    public int? UntilDate { get; init; }

    public bool? RevokeMessages { get; init; }
}
