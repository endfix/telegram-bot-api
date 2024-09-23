using System.Text.Json.Serialization;

namespace Telegram.BotAPI.Structs
{
    // https://core.telegram.org/bots/api#forcereply
    public class ForceReply : ReplyMarkupType
    {
        [JsonPropertyName("force_reply")]
        public bool IsforceReply { get; set; } = true;

        public string InputFieldPlaceholder { get; set; } = string.Empty;

        public bool Selective { get; set; }
    }
}
