using System.Collections.Generic;
using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>sendMessageDraft</c> method.
/// </summary>
public sealed class SendMessageDraftParameters : ApiRequestParameters
{
    /// <summary>Target private chat identifier.</summary>
    public required long ChatId { get; init; }

    /// <summary>Target message thread identifier.</summary>
    public long? MessageThreadId { get; init; }

    /// <summary>Non-zero draft identifier. Reusing an identifier animates changes to the same draft.</summary>
    public required long DraftId { get; init; }

    /// <summary>Draft text, from 0 through 4096 characters after entity parsing. An empty value shows a thinking placeholder.</summary>
    public string? Text { get; init; }

    /// <summary>Mode for parsing entities in <see cref="Text"/>.</summary>
    public string? ParseMode { get; init; }

    /// <summary>Special entities in <see cref="Text"/>; can be specified instead of <see cref="ParseMode"/>.</summary>
    public IReadOnlyList<MessageEntity>? Entities { get; init; }

    /// <summary>Whether to show a button that lets the user stop further drafts.</summary>
    public bool? CanStop { get; init; }

    /// <summary>Whether to keep the draft temporarily after the user stops generation.</summary>
    public bool? KeepOnStop { get; init; }
}
