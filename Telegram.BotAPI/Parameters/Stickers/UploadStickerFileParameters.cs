using Telegram.BotAPI.Types;

namespace Telegram.BotAPI.Parameters;

public sealed class UploadStickerFileParameters : ApiRequestParameters
{
    public long UserId { get; set; }

    public InputFile Sticker { get; set; }

    public string StickerFormat { get; set; }

    public static class Formats
    {
        public const string STATIC = "static";

        public const string ANIMATED = "animated";

        public const string VIDEO = "video";
    }
}
