using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

public sealed class UserProfileAudios
{
    public required int TotalCount {  get; init; }

    public required IReadOnlyList<Audio> Audios { get; init; }
}
