namespace Endfix.Telegram.BotAPI.Enums;

/// <summary>Identifies the formatting syntax used to parse entities in a text or caption.</summary>
/// <remarks>
/// The enum values use the exact strings accepted by the Bot API: <c>MarkdownV2</c>, <c>HTML</c>
/// and <c>Markdown</c>. The JSON converter configured by the library preserves these values.
/// </remarks>
public enum ParseMode
{
    /// <summary>MarkdownV2 formatting described in the Bot API formatting options.</summary>
    MarkdownV2,

    /// <summary>HTML formatting described in the Bot API formatting options.</summary>
    HTML,

    /// <summary>Legacy Markdown formatting described in the Bot API formatting options.</summary>
    Markdown
}
