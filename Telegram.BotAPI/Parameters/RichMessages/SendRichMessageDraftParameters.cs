using Endfix.Telegram.BotAPI.Protocol;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Parameters;

/// <summary>
/// Parameters for the <c>sendRichMessageDraft</c> method.
/// </summary>
public sealed class SendRichMessageDraftParameters : ApiRequestParameters
{
    /// <summary>Target private chat identifier.</summary>
    public required long ChatId { get; init; }

    /// <summary>Optional target message thread identifier.</summary>
    public long? MessageThreadId { get; init; }

    /// <summary>Non-zero draft identifier. Reusing it animates changes to the draft.</summary>
    public required long DraftId { get; init; }

    /// <summary>Partial rich message to stream. New file uploads are not supported.</summary>
    public required InputRichMessage RichMessage { get; init; }

    /// <summary>Whether to show the user a button for stopping further drafts.</summary>
    public bool? CanStop { get; init; }

    /// <summary>Whether to keep the draft after the user stops generation.</summary>
    public bool? KeepOnStop { get; init; }
}
