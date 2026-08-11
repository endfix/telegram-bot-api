using Xunit;

namespace Telegram.BotAPI.Tests.Integration;

internal sealed class TelegramIntegrationFactAttribute : FactAttribute
{
    public const string TokenVariable = "TELEGRAM_BOT_TOKEN";
    public const string ChatIdVariable = "TELEGRAM_BOT_CHAT_ID";
    public const string KeepMessagesVariable = "TELEGRAM_BOT_KEEP_MESSAGES";

    public TelegramIntegrationFactAttribute()
    {
        if (string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable(TokenVariable)) ||
            string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable(ChatIdVariable)))
        {
            Skip = $"Set {TokenVariable} and {ChatIdVariable} to run Telegram integration tests.";
        }
    }
}
