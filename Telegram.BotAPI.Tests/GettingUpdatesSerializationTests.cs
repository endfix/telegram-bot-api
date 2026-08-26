using Endfix.Telegram.BotAPI.Enums;
using Endfix.Telegram.BotAPI.Types;
using Xunit;

namespace Endfix.Telegram.BotAPI.Tests;

public class GettingUpdatesSerializationTests
{
    [Fact]
    public void Can_Roundtrip_Update()
    {
        Utils.AssertRoundtrip(new Update
        {
            UpdateId = 1001,
            Message = new() { 
                MessageId = 2002,
                MessageThreadId = 3003,
                Chat = new()
                {
                    Id = -1001234567890,
                    Type = ChatTypes.Supergroup
                },
                Date = 1_700_000_000,
                Text = "Deterministic update message"
            }
        });
    }

    [Fact]
    public void Can_Roundtrip_WebhookInfo()
    {
        Utils.AssertRoundtrip(new WebhookInfo
        {
            Url = "https://example.com/telegram/webhook",
            HasCustomCertificate = true,
            PendingUpdateCount = 7,
            IpAddress = "203.0.113.42",
            LastErrorDate = 1_700_000_001,
            LastErrorMessage = "Connection timed out",
            LastSynchronizationErrorDate = 1_700_000_002,
            MaxConnections = 40,
            AllowedUpdates = [UpdateType.Message, UpdateType.CallbackQuery, UpdateType.ChatMember]
        });
    }
}
