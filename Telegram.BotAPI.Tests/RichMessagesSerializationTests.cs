using Endfix.Telegram.BotAPI.Types;
using Xunit;

namespace Endfix.Telegram.BotAPI.Tests;

public class RichMessagesSerializationTests
{
    [Fact]
    public void Can_Roundtrip_RichMessage()
    {
        Utils.AssertRoundtrip(new RichMessage
        {
            Blocks = [
                new RichBlockParagraph { Text = new RichTextBold { Text = "Bold text" } },
                new RichBlockSectionHeading { Text = new RichTextItalic { Text = "Heading" }, Size = 1 },
                new RichBlockPreformatted { Text = "Console.WriteLine();", Language = "cs" },
                new RichBlockFooter { Text = new RichTextUnderline { Text = "Footer" } },
                new RichBlockDivider(),
                new RichBlockMathematicalExpression { Expression = "(\\w+)" },
                new RichBlockAnchor { Name = "#test" },
                new RichBlockList
                {
                    Items = [ new RichBlockListItem { Label = "Item #1", Blocks = [ new RichBlockThinking { Text = "..." } ], HasCheckbox = false, IsChecked = true, Value = 1, Type = "A" } ]
                },
                new RichBlockBlockQuotation { Blocks = [ new RichBlockAnchor { Name = "quote-anchor" } ], Credit = "Author" },
                new RichBlockPullQuotation { Text = "Quoted text", Credit = "Author" },
                new RichBlockCollage
                {
                    Blocks = [ new RichBlockAnchor { Name = "collage-anchor" } ],
                    Caption = GetRichBlockCaption()
                },
                new RichBlockSlideshow
                {
                    Blocks = [ new RichBlockThinking { Text = "Thinking..." } ],
                    Caption = GetRichBlockCaption()
                },
                new RichBlockTable
                {
                    Cells = [[ new RichBlockTableCell { Text = "Header", IsHeader = true, Colspan = 1, Rowspan = 1, Align = Enums.RichBlockTableCellAlign.Center, Valign = Enums.RichBlockTableCellVAlign.Middle } ]],
                    IsBordered = true, 
                    IsStriped = true, 
                    Caption = "Table caption"
                },
                new RichBlockDetails
                {
                    Summary = "Details",
                    Blocks = [ GetRichBlockMap() ],
                    IsOpen = true
                },
                GetRichBlockMap(),
                new RichBlockAnimation
                {
                    Animation = new Animation 
                    {
                        FileId = "animation-file-id",
                        FileUniqueId = "animation-unique-id",
                        Width = 100,
                        Height = 100,
                        Duration = 10
                    },
                    HasSpoiler = true,
                    Caption = GetRichBlockCaption()
                },
                new RichBlockAudio
                {
                    Audio = new Audio
                    {
                        FileId = "audio-file-id",
                        FileUniqueId = "audio-unique-id",
                        Duration = 10
                    },
                    Caption = GetRichBlockCaption()
                },
                new RichBlockPhoto
                {
                    Photos = [ new PhotoSize { FileId = "photo-file-id", FileUniqueId = "photo-unique-id", Width = 100, Height = 100 }],
                    HasSpoiler = true,
                    Caption = GetRichBlockCaption()
                },
                new RichBlockVideo
                {
                    Video = new Video
                    {
                        FileId = "video-file-id",
                        FileUniqueId = "video-unique-id",
                        Width = 100,
                        Height = 100,
                        Duration = 10
                    },
                    Caption = GetRichBlockCaption()
                },
                new RichBlockVoiceNote
                {
                    VoiceNote = new Voice 
                    {
                        FileId = "voice-file-id",
                        FileUniqueId = "voice-unique-id",
                        Duration = 10
                    },
                    Caption = GetRichBlockCaption()
                },
                new RichBlockThinking
                {
                    Text = "Thinking..."
                }
            ],
            IsRtl = true
        });
    }

    private static RichBlockCaption GetRichBlockCaption()
        => new() { Text = "Media caption", Credit = "Author" };

    private  static RichBlockMap GetRichBlockMap()
        => new() { 
            Location = new Location
            {
                Latitude = 55.7558,
                Longitude = 37.6173
            }, 
            Width = 100, 
            Height = 100, 
            Zoom = 1 
        };
}
