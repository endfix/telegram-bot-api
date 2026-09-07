using Microsoft.Extensions.Configuration;
using Xunit;

namespace Endfix.Telegram.BotAPI.Tests.Integration;

internal sealed class TelegramIntegrationFactAttribute : FactAttribute
{
    public const string TokenVariable = "TELEGRAM_BOT_TOKEN";
    public const string ChatIdVariable = "TELEGRAM_BOT_CHAT_ID";
    public const string GroupIdVariable = "TELEGRAM_BOT_GROUP_ID";
    public const string ForumIdVariable = "TELEGRAM_BOT_FORUM_ID";
    public const string ChannelIdVariable = "TELEGRAM_BOT_CHANNEL_ID";
    public const string TestUserIdVariable = "TELEGRAM_BOT_TEST_USER_ID";
    public const string KeepMessagesVariable = "TELEGRAM_BOT_KEEP_MESSAGES";
    public const string EmojiStatusAccessVariable = "TELEGRAM_BOT_EMOJI_STATUS_ACCESS";

    public TelegramIntegrationFactAttribute()
    {
        if (string.IsNullOrWhiteSpace(TelegramIntegrationSettings.Get(TokenVariable)) ||
            string.IsNullOrWhiteSpace(TelegramIntegrationSettings.Get(ChatIdVariable)))
        {
            Skip = $"Set {TokenVariable} and {ChatIdVariable} to run Telegram integration tests.";
        }
    }
}

internal sealed class TelegramForumIntegrationFactAttribute : FactAttribute
{
    public TelegramForumIntegrationFactAttribute()
    {
        var missing = TelegramIntegrationSettings.Missing(
            TelegramIntegrationFactAttribute.TokenVariable,
            TelegramIntegrationFactAttribute.ForumIdVariable);
        if (missing.Count > 0)
        {
            Skip = $"Set {string.Join(", ", missing)} to run Telegram forum integration tests.";
        }
    }
}

internal sealed class TelegramGroupIntegrationFactAttribute : FactAttribute
{
    public TelegramGroupIntegrationFactAttribute()
    {
        var missing = TelegramIntegrationSettings.Missing(
            TelegramIntegrationFactAttribute.TokenVariable,
            TelegramIntegrationFactAttribute.GroupIdVariable);
        if (missing.Count > 0)
        {
            Skip = $"Set {string.Join(", ", missing)} to run Telegram group integration tests.";
        }
    }
}

internal sealed class TelegramChannelIntegrationFactAttribute : FactAttribute
{
    public TelegramChannelIntegrationFactAttribute()
    {
        var missing = TelegramIntegrationSettings.Missing(
            TelegramIntegrationFactAttribute.TokenVariable,
            TelegramIntegrationFactAttribute.ChannelIdVariable);
        if (missing.Count > 0)
        {
            Skip = $"Set {string.Join(", ", missing)} to run Telegram channel integration tests.";
        }
    }
}

internal sealed class TelegramModerationIntegrationFactAttribute : FactAttribute
{
    public TelegramModerationIntegrationFactAttribute()
    {
        var missing = TelegramIntegrationSettings.Missing(
            TelegramIntegrationFactAttribute.TokenVariable,
            TelegramIntegrationFactAttribute.GroupIdVariable,
            TelegramIntegrationFactAttribute.TestUserIdVariable);
        if (missing.Count > 0)
        {
            Skip = $"Set {string.Join(", ", missing)} to run Telegram moderation integration tests.";
        }
    }
}

internal sealed class TelegramPremiumIntegrationFactAttribute : FactAttribute
{
    public TelegramPremiumIntegrationFactAttribute()
    {
        var missing = TelegramIntegrationSettings.Missing(
            TelegramIntegrationFactAttribute.TokenVariable,
            TelegramIntegrationFactAttribute.ChatIdVariable,
            TelegramIntegrationFactAttribute.GroupIdVariable);
        if (missing.Count > 0)
        {
            Skip = $"Set {string.Join(", ", missing)} to run Telegram Premium integration tests.";
        }
    }
}

internal sealed class TelegramEmojiStatusIntegrationFactAttribute : FactAttribute
{
    public TelegramEmojiStatusIntegrationFactAttribute()
    {
        var missing = TelegramIntegrationSettings.Missing(
            TelegramIntegrationFactAttribute.TokenVariable,
            TelegramIntegrationFactAttribute.ChatIdVariable,
            TelegramIntegrationFactAttribute.GroupIdVariable);
        if (missing.Count > 0)
        {
            Skip = $"Set {string.Join(", ", missing)} to run the Telegram emoji-status integration test.";
            return;
        }

        if (!bool.TryParse(
                TelegramIntegrationSettings.Get(TelegramIntegrationFactAttribute.EmojiStatusAccessVariable),
                out var accessGranted) || !accessGranted)
        {
            Skip = $"Grant emoji-status access through the Mini App and set " +
                $"{TelegramIntegrationFactAttribute.EmojiStatusAccessVariable}=true to run this test.";
        }
    }
}

internal sealed class TelegramRoutingIntegrationFactAttribute : FactAttribute
{
    public TelegramRoutingIntegrationFactAttribute()
    {
        var missing = TelegramIntegrationSettings.Missing(
            TelegramIntegrationFactAttribute.TokenVariable,
            TelegramIntegrationFactAttribute.ChatIdVariable,
            TelegramIntegrationFactAttribute.GroupIdVariable,
            TelegramIntegrationFactAttribute.ChannelIdVariable);
        if (missing.Count > 0)
        {
            Skip = $"Set {string.Join(", ", missing)} to run Telegram routing integration tests.";
        }
    }
}

internal static class TelegramIntegrationSettings
{
    private static readonly IConfigurationRoot Secrets = new ConfigurationBuilder()
        .AddUserSecrets<TelegramIntegrationFactAttribute>(optional: true)
        .Build();

    public static string? Get(string name)
        => Environment.GetEnvironmentVariable(name) ?? Secrets[name];

    public static IReadOnlyList<string> Missing(params string[] names)
        => names.Where(name => string.IsNullOrWhiteSpace(Get(name))).ToArray();
}
