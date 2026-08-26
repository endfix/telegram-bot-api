using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

public sealed class UserProfilePhotos
{
    public required int TotalCount { get; init; }

    public required IReadOnlyList<IReadOnlyList<PhotoSize>> Photos { get; init; }
}
