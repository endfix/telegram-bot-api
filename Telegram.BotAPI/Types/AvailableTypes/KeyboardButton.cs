using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

public sealed class KeyboardButton
{
    public required string Text { get; init; }

    public string? IconCustomEmojiId { get; init; }

    public KeyboardButtonStyle? Style { get; init; }

    public KeyboardButtonRequestUsers? RequestUsers { get; init; }

    public KeyboardButtonRequestChat? RequestChat { get; init; }

    public KeyboardButtonRequestManagedBot? RequestManagedBot { get; init; }

    public bool? RequestContact { get; init; }

    public bool? RequestLocation { get; init; }

    public KeyboardButtonPollType? RequestPoll { get; init; }

    public WebAppInfo? WebApp { get; init; }
}
