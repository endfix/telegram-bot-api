using Xunit;

namespace Telegram.BotAPI.Tests.Integration;

internal sealed class TelegramIntegrationFactAttribute : FactAttribute
{
    public const string TokenVariable = "TELEGRAM_BOT_TOKEN";
    public const string ChatIdVariable = "TELEGRAM_BOT_CHAT_ID";
    public const string KeepMessagesVariable = "TELEGRAM_BOT_KEEP_MESSAGES";
    public const string VideoPathVariable = "TELEGRAM_BOT_TEST_VIDEO_PATH";
    public const string ImagePathVariable = "TELEGRAM_BOT_TEST_IMAGE_PATH";
    public const string ThumbnailPathVariable = "TELEGRAM_BOT_TEST_THUMBNAIL_PATH";
    public const string CoverPathVariable = "TELEGRAM_BOT_TEST_COVER_PATH";

    public TelegramIntegrationFactAttribute()
    {
        if (string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable(TokenVariable)) ||
            string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable(ChatIdVariable)))
        {
            Skip = $"Set {TokenVariable} and {ChatIdVariable} to run Telegram integration tests.";
        }
    }
}

internal sealed class TelegramMediaIntegrationFactAttribute : FactAttribute
{
    public TelegramMediaIntegrationFactAttribute()
    {
        var requiredVariables = new[]
        {
            TelegramIntegrationFactAttribute.TokenVariable,
            TelegramIntegrationFactAttribute.ChatIdVariable,
            TelegramIntegrationFactAttribute.VideoPathVariable,
            TelegramIntegrationFactAttribute.ImagePathVariable,
            TelegramIntegrationFactAttribute.ThumbnailPathVariable,
            TelegramIntegrationFactAttribute.CoverPathVariable
        };

        if (requiredVariables.Any(variable =>
            string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable(variable))))
        {
            Skip = $"Set {string.Join(", ", requiredVariables)} to run Telegram media integration tests.";
        }
    }
}
