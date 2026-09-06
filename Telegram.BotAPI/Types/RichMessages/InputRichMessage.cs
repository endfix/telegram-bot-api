using System.Collections.Generic;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>Describes a rich message to be sent.</summary>
/// <remarks>Exactly one of <see cref="Html"/>, <see cref="Markdown"/> or <see cref="Blocks"/> must be specified.</remarks>
public sealed class InputRichMessage
{
    /// <summary>Optional. Content of the rich message described as a list of blocks.</summary>
    public IReadOnlyList<InputRichBlock>? Blocks { get; init; }

    /// <summary>Optional. Content of the rich message described using HTML formatting.</summary>
    public string? Html { get; init; }

    /// <summary>Optional. Content of the rich message described using Markdown formatting.</summary>
    public string? Markdown { get; init; }

    /// <summary>Optional. Indicates whether the rich message must be shown right-to-left.</summary>
    public bool? IsRtl { get; init; }

    /// <summary>Optional. Media referenced from the HTML or Markdown content by Telegram media links.</summary>
    public IReadOnlyList<InputRichMessageMedia>? Media { get; init; }

    /// <summary>Optional. Pass <see langword="true"/> to skip automatic entity detection in the text.</summary>
    public bool? SkipEntityDetection { get; init; }
}
