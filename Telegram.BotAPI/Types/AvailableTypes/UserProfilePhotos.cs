namespace Telegram.BotAPI.Types;

public sealed class UserProfilePhotos
{
    public int TotalCount { get; set; }

    public PhotoSize[][] Photos { get; set; }
}
