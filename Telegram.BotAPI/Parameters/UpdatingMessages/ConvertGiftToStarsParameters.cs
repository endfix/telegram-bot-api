namespace Telegram.BotAPI.Parameters;

public sealed class ConvertGiftToStarsParameters : ApiRequestParameters
{
    public string BusinessConnectionId { get; set; }

    public string OwnedGiftId { get; set; }
}
