using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>postStory</c> method.
/// </summary>
public sealed class PostStoryParameters : ApiRequestParameters
{
    /// <summary>Identifier of the business connection.</summary>
    public required string BusinessConnectionId { get; init; }

    /// <summary>Content of the story.</summary>
    public required InputStoryContent Content { get; init; }

    /// <summary>Seconds after which the story is moved to the archive; must be 21600, 43200, 86400 or 172800.</summary>
    public required int ActivePeriod { get; init; }

    /// <summary>Caption for the story, containing up to 2048 characters after entity parsing.</summary>
    public string? Caption { get; init; }
    
    /// <summary>Mode used to parse entities in <see cref="Caption"/>.</summary>
    public string? ParseMode { get; init; }

    /// <summary>Special entities in the caption, specified instead of <see cref="ParseMode"/>.</summary>
    public IReadOnlyList<MessageEntity>? CaptionEntities { get; init; }

    /// <summary>Interactive areas placed on the story.</summary>
    public IReadOnlyList<StoryArea>? Areas { get; init; }

    /// <summary>Whether to keep the story accessible on the business account's profile after it expires.</summary>
    public bool? PostToChatPage { get; init; }

    /// <summary>Whether to protect the story from forwarding and screenshots.</summary>
    public bool? ProtectContent { get; init; }
}
