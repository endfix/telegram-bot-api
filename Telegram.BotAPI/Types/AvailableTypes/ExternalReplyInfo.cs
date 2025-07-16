namespace Telegram.BotAPI.Types;

public sealed class ExternalReplyInfo
{
    public MessageOrigin Origin { get; set; }

    public Chat Chat { get; set; }

    public long MessageId { get; set; }

    public LinkPreviewOptions LinkRreviewOptions { get; set; }

    public Animation Animation { get; set; }

    public Audio Audio { get; set; }

    public Document Document { get; set; }

    public PaidMediaInfo PaidMedia { get; set; }

    public PhotoSize[] Photo { get; set; }

    public Sticker Sticker { get; set; }

    public Story Story { get; set; }

    public Video Video { get; set; }

    public VideoNote VideoNote { get; set; }

    public Voice Voice { get; set; }

    public bool HasMediaSpoiler { get; set; }

    public Contact Contact { get; set; }

    public Dice Dice { get; set; }

    public Game Game { get; set; }

    public Giveaway Giveaway { get; set; }

    public GiveawayWinners GiveawayWinners { get; set; }

    public Invoice Invoice { get; set; }

    public Location Location { get; set; }

    public Poll Poll { get; set; }

    public Venue Venue { get; set; }
}
