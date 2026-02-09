namespace Telegram.BotAPI.Parameters;

public sealed class GetUserProfileAudiosParameters : ApiRequestParameters
{
    public required long UserId { get; set; }

    public int? Offset { get; set; } = null;

    public int? Limit { get; set; } = null;
}
