namespace Telegram.BotAPI.Parameters;

public sealed class RemoveBusinessAccountProfilePhotoParameters : ApiRequestParameters
{
    public string BusinessConnectionId { get; set; }

    public bool IsPublic { get; set; }
}
