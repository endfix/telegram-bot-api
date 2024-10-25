namespace Telegram.BotAPI;

public class ResponseAPI<T>
{
    public bool Ok { get; set; }

    public int ErrorCode { get; set; }

    public string Description { get; set; }

    public T Result { get; set; }
}
