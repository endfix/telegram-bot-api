namespace Telegram.BotAPI.Parameters;

public sealed class GetUpdatesParameters : ApiRequestParameters
{
    public long Offset { get; set; }

    public int Limit { get; set; }

    public int Timeout { get; set; }

    public string[] AllowedUpdates { get; set; }
}
