namespace Telegram.BotAPI;

public sealed class ApiContext<T>
{
    public ApiRequest Request { get; set; }

    public ApiResponse<T> Response { get; set; }
}
