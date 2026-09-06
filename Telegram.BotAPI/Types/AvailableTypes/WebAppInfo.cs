namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Describes a Web App URL.</summary>
public sealed class WebAppInfo
{
    /// <summary>HTTPS URL of the Web App.</summary>
    public required string Url { get; init; }
}
