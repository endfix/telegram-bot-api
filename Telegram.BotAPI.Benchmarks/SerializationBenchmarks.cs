using System.Collections.Generic;
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
    private RichText _richText = null!;
    private RichMessage _richMessage = null!;
    private string _richTextJson = null!;
    private string _richMessageJson = null!;

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

        _richText = new RichTextBold
        {
            Text = new RichTextItalic { Text = "Benchmark rich text" }
        };

        _richMessage = new RichMessage
        {
            Blocks = [
                new RichBlockSectionHeading
                {
                    Text = new RichTextBold { Text = "Benchmark heading" },
                    Size = 2
                },
                new RichBlockParagraph
                {
                    Text = new RichTextItalic { Text = "Benchmark paragraph" }
                },
                new RichBlockBlockQuotation
                {
                    Blocks = [
                        new RichBlockParagraph
                        {
                            Text = new RichTextUnderline { Text = "Nested quote" }
                        }
                    ],
                    Credit = "Benchmark author"
                },
                new RichBlockList
                {
                    Items = [
                        new RichBlockListItem
                        {
                            Label = "Item",
                            Blocks = [new RichBlockThinking { Text = "Thinking" }],
                            HasCheckbox = true,
                            IsChecked = false,
                            Value = 1,
                            Type = "A"
                        }
                    ]
                },
                new RichBlockDivider()
            ],
            IsRtl = false
        };

        _richTextJson = _richText.Serialize();
        _richMessageJson = _richMessage.Serialize();
    }

    [Benchmark]
    public string SerializeParameters() => _parameters.Serialize();

    [Benchmark]
    public SendMessageParameters? DeserializeParameters() => _parametersJson.Deserialize<SendMessageParameters>();

    [Benchmark]
    public string SerializeMessage() => _message.Serialize();

    [Benchmark]
    public Message? DeserializeMessage() => _messageJson.Deserialize<Message>();

    [Benchmark]
    public string SerializeRichText() => _richText.Serialize();

    [Benchmark]
    public RichText? DeserializeRichText() => _richTextJson.Deserialize<RichText>();

    [Benchmark]
    public string SerializeRichMessage() => _richMessage.Serialize();

    [Benchmark]
    public RichMessage? DeserializeRichMessage() => _richMessageJson.Deserialize<RichMessage>();
}

[MemoryDiagnoser]
public class RichMessageComplexityBenchmarks
{
    [Params(1, 5, 10, 50)]
    public int BlockCount { get; set; }

    private RichMessage _message = null!;
    private string _messageJson = null!;

    [GlobalSetup]
    public void Setup()
    {
        var blocks = new List<RichBlock>(BlockCount);

        for (var i = 0; i < BlockCount; i++)
        {
            blocks.Add(new RichBlockParagraph
            {
                Text = new RichTextBold
                {
                    Text = new RichTextItalic { Text = $"Benchmark paragraph {i}" }
                }
            });
        }

        _message = new RichMessage
        {
            Blocks = blocks,
            IsRtl = false
        };

        _messageJson = _message.Serialize();
    }

    [Benchmark]
    public string Serialize() => _message.Serialize();

    [Benchmark]
    public RichMessage? Deserialize() => _messageJson.Deserialize<RichMessage>();
}
