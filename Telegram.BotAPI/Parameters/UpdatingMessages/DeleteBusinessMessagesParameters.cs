namespace Telegram.BotAPI.Parameters;

public sealed class DeleteBusinessMessagesParameters : ApiRequestParameters
{
    public string BusinessConnectionId {  get; set; }

    public int[] MessageIds { get; set; }
}
