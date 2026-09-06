using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Represents a user's profile pictures.</summary>
public sealed class UserProfilePhotos
{
    /// <summary>Total number of profile pictures the target user has.</summary>
    public required int TotalCount { get; init; }

    /// <summary>Requested profile pictures, each represented by one or more available sizes.</summary>
    public required IReadOnlyList<IReadOnlyList<PhotoSize>> Photos { get; init; }
}
