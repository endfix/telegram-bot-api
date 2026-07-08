using Telegram.BotAPI.Types;
using Xunit;

namespace Telegram.BotAPI.Tests;

public class RichMessagesSerializationTests
{
    [Fact]
    public void Can_Roundtrip_RichMessage()
    {
        Utils.AssertRoundtrip(new RichMessage
        {
            Blocks = [
                new RichBlockParagraph { Text = new RichTextBold { Text = Utils.GetRandomText(10) } },
                new RichBlockSectionHeading { Text = new RichTextItalic { Text = Utils.GetRandomText(10) }, Size = 1 },
                new RichBlockPreformatted { Text = Utils.GetRandomText(10), Language = "cs" },
                new RichBlockFooter { Text = new RichTextUnderline { Text = Utils.GetRandomText(10) } },
                new RichBlockDivider(),
                new RichBlockMathematicalExpression { Expression = "(\\w+)" },
                new RichBlockAnchor { Name = "#test" },
                new RichBlockList
                {
                    Items = [ new RichBlockListItem { Label = "Item #1", Blocks = [ new RichBlockThinking { Text = "..." } ], HasCheckbox = false, IsChecked = true, Value = 1, Type = "A" } ]
                },
                new RichBlockBlockQuotation { Blocks = [ new RichBlockAnchor { Name = Utils.GetRandomText(10) } ], Credit = "Credit" },
                new RichBlockPullQuotation { Text = Utils.GetRandomText(10), Credit = Utils.GetRandomText(10) },
                new RichBlockCollage
                {
                    Blocks = [ new RichBlockAnchor { Name = Utils.GetRandomText(10) } ],
                    Caption = GetRichBlockCaption()
                },
                new RichBlockSlideshow
                {
                    Blocks = [ new RichBlockThinking { Text = Utils.GetRandomText(10) } ],
                    Caption = GetRichBlockCaption()
                },
                new RichBlockTable
                {
                    Cells = [[ new RichBlockTableCell { Text = Utils.GetRandomText(10), IsHeader = Utils.GetRandomBool(),Colspan = 1, Rowspan = 1, Align = Enums.RichBlockTableCellAlign.Center, Valign = Enums.RichBlockTableCellVAlign.Middle } ]], 
                    IsBordered = true, 
                    IsStriped = true, 
                    Caption = Utils.GetRandomText(10)
                },
                new RichBlockDetails
                {
                    Summary = Utils.GetRandomText(10),
                    Blocks = [ GetRichBlockMap() ],
                    IsOpen = true
                },
                GetRichBlockMap(),
                new RichBlockAnimation
                {
                    Animation = new Animation 
                    {
                        FileId = Utils.GetRandomText(10),
                        FileUniqueId = Utils.GetRandomText(10),
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
                        FileId = Utils.GetRandomText(10),
                        FileUniqueId = Utils.GetRandomText(10),
                        Duration = 10
                    },
                    Caption = GetRichBlockCaption()
                },
                new RichBlockPhoto
                {
                    Photos = [ new PhotoSize { FileId = Utils.GetRandomText(10), FileUniqueId = Utils.GetRandomText(10), Width = 100, Height = 100 }],
                    HasSpoiler = true,
                    Caption = GetRichBlockCaption()
                },
                new RichBlockVideo
                {
                    Video = new Video
                    {
                        FileId = Utils.GetRandomText(10),
                        FileUniqueId = Utils.GetRandomText(10),
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
                        FileId = Utils.GetRandomText(10),
                        FileUniqueId = Utils.GetRandomText(10),
                        Duration = 10
                    },
                    Caption = GetRichBlockCaption()
                },
                new RichBlockThinking
                {
                    Text = Utils.GetRandomText(10)
                }
            ],
            IsRtl = true
        });
    }

    private static RichBlockCaption GetRichBlockCaption()
        => new() { Text = Utils.GetRandomText(10), Credit = Utils.GetRandomText(10) };

    private  static RichBlockMap GetRichBlockMap()
        => new() { 
            Location = new Location
            {
                Latitude = Utils.GetRandomDouble(),
                Longitude = Utils.GetRandomDouble()
            }, 
            Width = 100, 
            Height = 100, 
            Zoom = 1 };
}
