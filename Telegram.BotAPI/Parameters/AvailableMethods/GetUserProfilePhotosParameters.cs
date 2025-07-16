namespace Telegram.BotAPI.Parameters;

public sealed class GetUserProfilePhotosParameters : ApiRequestParameters
{
    public long UserId { get; set; }

    public int Offset { get; set; }

    public int Limit { get; set; }
}
