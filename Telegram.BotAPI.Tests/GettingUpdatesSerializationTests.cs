using Telegram.BotAPI.Enums;
using Telegram.BotAPI.Types;
using Xunit;

namespace Telegram.BotAPI.Tests;

public class GettingUpdatesSerializationTests
{
    [Fact]
    public void Can_Roundtrip_Update()
    {
        Utils.AssertRoundtrip(new Update
        {
            UpdateId = Utils.GetRandomLong(),
            Message = new() { 
                MessageId = Utils.GetRandomLong(),
                MessageThreadId = Utils.GetRandomLong(),
                Chat = new()
                {
                    Id = Utils.GetRandomLong(),
                    Type = Utils.GetRandomEnum<ChatTypes>()
                },
                Date = Utils.GetRandomLong(),
                Text = Utils.GetRandomText()
            }
        });
    }

    [Fact]
    public void Can_Roundtrip_WebhookInfo()
    {
        Utils.AssertRoundtrip(new WebhookInfo
        {
            Url = Utils.GetRandomText(2048),
            HasCustomCertificate = Utils.GetRandomBool(),
            PendingUpdateCount = Utils.GetRandomInt(),
            IpAddress = Utils.GetRandomText(39),
            LastErrorDate = Utils.GetRandomLong(),
            LastErrorMessage = Utils.GetRandomText(255),
            LastSynchronizationErrorDate = Utils.GetRandomLong(),
            MaxConnections = Utils.GetRandomInt(),
            AllowedUpdates = [ Utils.GetRandomEnum<UpdateType>(), Utils.GetRandomEnum<UpdateType>(), Utils.GetRandomEnum<UpdateType>() ]
        });
    }
}
