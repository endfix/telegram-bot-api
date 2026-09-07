using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>editStory</c> method.
/// </summary>
public sealed class EditStoryParameters : ApiRequestParameters
{
    /// <summary>Identifier of the business connection.</summary>
    public required string BusinessConnectionId { get; init; }

    /// <summary>Identifier of the story to edit.</summary>
    public required int StoryId { get; init; }

    /// <summary>New content of the story.</summary>
    public required InputStoryContent Content { get; init; }

    /// <summary>New caption for the story, containing up to 2048 characters after entity parsing.</summary>
    public string? Caption { get; init; }

    /// <summary>Mode used to parse entities in <see cref="Caption"/>.</summary>
    public string? ParseMode { get; init; }

    /// <summary>Special entities in the caption, specified instead of <see cref="ParseMode"/>.</summary>
    public IReadOnlyList<MessageEntity>? CaptionEntities { get; init; }

    /// <summary>New interactive areas placed on the story.</summary>
    public IReadOnlyList<StoryArea>? Areas { get; init; }
}
