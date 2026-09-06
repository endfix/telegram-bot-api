namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Contains parameters of a post that is being suggested by the bot.
/// </summary>
public sealed class SuggestedPostParameters
{
    /// <summary>Optional proposed price for the post. If omitted, the post is unpaid.</summary>
    public SuggestedPostPrice? Price { get; init; }

    /// <summary>Optional proposed publication date in Unix time.</summary>
    public int? SendDate { get; init; }
}
