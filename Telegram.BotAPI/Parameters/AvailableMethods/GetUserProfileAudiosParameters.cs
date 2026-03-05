namespace Telegram.BotAPI.Parameters;

public sealed class GetUserProfileAudiosParameters : ApiRequestParameters
{
    public required long UserId { get; set; }

    public int? Offset { get; set; }

    public int? Limit { get; set; }
}
