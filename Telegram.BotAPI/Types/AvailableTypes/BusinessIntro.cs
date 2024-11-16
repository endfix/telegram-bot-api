using Telegram.BotAPI.Types.Stickers;

namespace Telegram.BotAPI.Types.AvailableTypes;

public sealed class BusinessIntro
{
    public string Name { get; set; }

    public string Message { get; set; }

    public Sticker Sticker { get; set; }
}
