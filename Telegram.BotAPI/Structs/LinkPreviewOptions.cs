namespace Telegram.BotAPI.Structs
{
    // https://core.telegram.org/bots/api#linkpreviewoptions
    public class LinkPreviewOptions
    {
        public bool IsDisabled { get; set; }

        public string Url { get; set; } = string.Empty;

        public bool PreferSmallMedia { get; set; }

        public bool PreferLargeMedia { get; set; }

        public bool ShowAboveText { get; set; }
    }
}
