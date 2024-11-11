namespace Telegram.BotAPI.Core;

public sealed class ResponseAPI<T>
{
    public bool Ok { get; set; }

    public int ErrorCode { get; set; }

    public string Description { get; set; }

    public Parameters Parameters { get; set; }

    public T Result { get; set; }
}

public sealed class Parameters
{
    public int RetryAfter { get; set; }

    public long MigrateToChatId { get; set; }
}
