namespace Telegram.BotAPI.Parameters;

public sealed class GetChatGiftsParameters : ApiRequestParameters
{
    public object ChatId { get; set; }

    public bool ExcludeUnsaved { get; set; }

    public bool ExcludeSaved { get; set; }

    public bool ExcludeUnlimited { get; set; }

    public bool ExcludeLimitedUpgradable { get; set; }

    public bool ExcludeLimitedNonUpgradable { get; set; }

    public bool ExcludeFromBlockchain { get; set; }

    public bool ExcludeUnique { get; set; }

    public bool SortByPrice { get; set; }

    public string Offset { get; set; }

    public int Limit { get; set; }
}
