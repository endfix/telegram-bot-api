using Telegram.BotAPI.Types.Stickers;

namespace Telegram.BotAPI.Types;

// https://core.telegram.org/bots/api#businessintro
public sealed class BusinessIntro
{
    public string Name { get; set; }

    public string Message { get; set; }

    public Sticker Sticker { get; set; }
}
