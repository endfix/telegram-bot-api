using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

public sealed class EditStoryParameters : ApiRequestParameters
{
    public required string BusinessConnectionId { get; init; }

    public required int StoryId { get; init; }

    public required InputStoryContent Content { get; init; }

    public string? Caption { get; init; }

    public string? ParseMode { get; init; }

    public IReadOnlyList<MessageEntity>? CaptionEntities { get; init; }

    public IReadOnlyList<StoryArea>? Areas { get; init; }
}
