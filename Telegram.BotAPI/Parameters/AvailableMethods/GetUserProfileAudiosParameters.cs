namespace Telegram.BotAPI.Parameters;

public sealed class GetUserProfileAudiosParameters : ApiRequestParameters
{
    public required long UserId { get; init; }

    public int? Offset { get; init; }

    public int? Limit { get; init; }
}
