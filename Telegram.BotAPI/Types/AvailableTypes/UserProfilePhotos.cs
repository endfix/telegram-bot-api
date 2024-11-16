using System.Collections.Generic;

namespace Telegram.BotAPI.Types.AvailableTypes;

public sealed class UserProfilePhotos
{
    public int TotalCount { get; set; }

    public List<List<PhotoSize>> Photos { get; set; }
}
