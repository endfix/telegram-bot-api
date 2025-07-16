using Telegram.BotAPI.Types;
namespace Telegram.BotAPI.Parameters;

public sealed class CreateNewStickerSetParameters : ApiRequestParameters
{
    public long UserId { get; set; }

    public string Name { get; set; }

    public string Title { get; set; }

    public InputSticker[] Stickers { get; set; }

    public string StickerType { get; set; }

    public bool NeedsRepainting { get; set; }

    public static class Types
    {
        public const string REGULAR = "regular";

        public const string MASK = "mask";

        public const string CUSTOM_EMOJI = "custom_emoji";
    }
}
