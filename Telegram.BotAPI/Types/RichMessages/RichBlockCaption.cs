namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Describes a caption attached to a rich media block.</summary>
public sealed class RichBlockCaption
{
    /// <summary>Caption text.</summary>
    public required RichTextSource Text { get; init; }

    /// <summary>Optional. Credit displayed with the caption.</summary>
    public RichTextSource? Credit { get; init; }
}
