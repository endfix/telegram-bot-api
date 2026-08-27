using BenchmarkDotNet.Attributes;
using Endfix.Telegram.BotAPI.Extensions;
using Endfix.Telegram.BotAPI.Parameters;
using Endfix.Telegram.BotAPI.Types;

namespace Endfix.Telegram.BotAPI.Benchmarks;

[MemoryDiagnoser]
public class SerializationBenchmarks
{
    private SendMessageParameters _parameters = null!;
    private Message _message = null!;
    private string _parametersJson = null!;
    private string _messageJson = null!;

    [GlobalSetup]
    public void Setup()
    {
        _parameters = new SendMessageParameters
        {
            ChatId = 989722390L,
            MessageThreadId = 42,
            Text = "Benchmark message",
            ParseMode = "HTML",
            DisableNotification = true
        };

        _message = new Message
        {
            MessageId = 1001,
            Date = 1786471241,
            Chat = new Chat
            {
                Id = 989722390,
                Type = Enums.ChatTypes.Private,
                FirstName = "Benchmark"
            },
            Text = "Benchmark response"
        };

        _parametersJson = _parameters.Serialize();
        _messageJson = _message.Serialize();
    }

    [Benchmark]
    public string SerializeParameters() => _parameters.Serialize();

    [Benchmark]
    public SendMessageParameters? DeserializeParameters() => _parametersJson.Deserialize<SendMessageParameters>();

    [Benchmark]
    public string SerializeMessage() => _message.Serialize();

    [Benchmark]
    public Message? DeserializeMessage() => _messageJson.Deserialize<Message>();
}
