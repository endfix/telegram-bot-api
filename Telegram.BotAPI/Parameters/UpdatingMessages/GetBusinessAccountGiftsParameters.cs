namespace Telegram.BotAPI.Parameters;

public class GetBusinessAccountGiftsParameters : ApiRequestParameters
{
    public string BusinessConnectionId { get; set; }

    public bool ExcludeUnsaved { get; set; }

    public bool ExcludeSaved { get; set; }

    public bool ExcludeUnlimited { get; set; }

    public bool ExcludeLimited { get; set; }

    public bool ExcludeUnique { get; set; }

    public bool SortByPrice { get; set; }

    public string Offset { get; set; }

    public int Limit { get; set; }
}
