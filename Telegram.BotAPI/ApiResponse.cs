using System.Text.Json.Serialization;

namespace Telegram.BotAPI;

public sealed class ApiResponse<T>
{
    public bool Ok { get; set; }

    public int ErrorCode { get; set; }

    public string Description { get; set; }

    public ApiResponseParameters Parameters { get; set; }

    public T Result { get; set; }

    [JsonIgnore]
    public string Raw { get; set; }
}
