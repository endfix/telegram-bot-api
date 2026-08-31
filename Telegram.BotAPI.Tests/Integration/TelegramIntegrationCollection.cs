using Xunit;

namespace Endfix.Telegram.BotAPI.Tests.Integration;

[CollectionDefinition(Name, DisableParallelization = true)]
public sealed class TelegramIntegrationCollection
{
    public const string Name = "Telegram integration";
}
