using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

public abstract class InputStoryContent
{
    public abstract InputStoryContentTypes Type { get; }
}

public sealed class InputStoryContentPhoto : InputStoryContent
{
    public override InputStoryContentTypes Type => throw new System.NotImplementedException();

    public string Photo { get; set; }
}

public sealed class InputStoryContentVideo : InputStoryContent
{
    public override InputStoryContentTypes Type => throw new System.NotImplementedException();

    public string Video { get; set; }

    public float Duration { get; set; }

    public float CoverFrameTimestamp { get; set; }

    public bool IsAnimation { get; set; }
}