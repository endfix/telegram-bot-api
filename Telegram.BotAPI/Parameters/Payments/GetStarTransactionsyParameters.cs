namespace Telegram.BotAPI.Parameters;

public sealed class GetStarTransactionsyParameters : ApiRequestParameters
{
    public int Offset { get; set; }

    public int Limit { get; set; }
}
