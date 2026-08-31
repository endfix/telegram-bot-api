using System.Text.Json.Serialization;

namespace Endfix.Telegram.BotAPI.Protocol;

public sealed class ApiResponse<T>
{
    [JsonRequired]
    public bool Ok { get; set; }

    public int ErrorCode { get; set; }

    public string? Description { get; set; }

    public ApiResponseParameters? Parameters { get; set; }

    public T Result { get; set; } = default!;
}
