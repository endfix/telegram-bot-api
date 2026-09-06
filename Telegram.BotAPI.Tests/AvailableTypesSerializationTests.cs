using Endfix.Telegram.BotAPI.Types;
using Xunit;

namespace Endfix.Telegram.BotAPI.Tests;

public class AvailableTypesSerializationTests
{
    [Fact]
    public void DirectMessagesTopic_PreservesLargeTopicId()
    {
        Utils.AssertRoundtrip(new DirectMessagesTopic
        {
            TopicId = 1L << 40
        });
    }
}
