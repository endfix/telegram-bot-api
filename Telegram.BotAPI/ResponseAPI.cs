using System.Text.Json.Serialization;

namespace Telegram.BotAPI
{
    public class ResponseAPI<T>
    {
        [JsonPropertyName("ok")]
        public bool Ok { get; set; }

        [JsonPropertyName("error_code")]
        public int ErrorCode { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;

        [JsonPropertyName("result")]
        public T Result { get; set; }
    }
}
