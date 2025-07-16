namespace Telegram.BotAPI.Parameters;

public sealed class SetStickerSetTitleParameters : ApiRequestParameters
{
    public string Name { get; set; }

    public string Title { get; set; }
}
