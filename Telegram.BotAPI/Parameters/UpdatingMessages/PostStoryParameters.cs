using System.Collections.Generic;
using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class PostStoryParameters : ApiRequestParameters
{
    public required string BusinessConnectionId { get; init; }

    public required InputStoryContent Content { get; init; }

    public required int ActivePeriod { get; init; }

    public string? Caption { get; init; }
    
    public string? ParseMode { get; init; }

    public IReadOnlyList<MessageEntity>? CaptionEntities { get; init; }

    public IReadOnlyList<StoryArea>? Areas { get; init; }

    public bool? PostToChatPage { get; init; }

    public bool? ProtectContent { get; init; }
}
