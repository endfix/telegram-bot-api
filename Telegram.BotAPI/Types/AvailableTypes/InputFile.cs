using Endfix.Telegram.BotAPI.Enums;
using System.IO;

namespace Endfix.Telegram.BotAPI.Types;

/// <summary>
/// Represents a typed file uploaded with a Telegram API request.
/// </summary>
public abstract class InputFile
{
    private readonly InputFileSource _source;

    protected InputFile(string path)
        : this(InputFileSource.FromPath(path))
    {
    }

    protected InputFile(InputFileSource source)
    {
        _source = source ?? throw new System.ArgumentNullException(nameof(source));
    }

    public abstract InputFileType Type { get; }

    public string FileName => _source.FileName;

    /// <summary>
    /// Opens a new, independent readable stream. Reading begins at the stream's
    /// current position; the library does not seek or rewind it. The caller owns
    /// and must dispose the returned stream. Each call remains valid independently
    /// of streams returned by earlier or concurrent calls.
    /// </summary>
    public Stream GetStream() => _source.OpenRead();
}

public sealed class InputCertificateFile : InputFile
{
    public InputCertificateFile(string path) : base(path) { }
    public InputCertificateFile(InputFileSource source) : base(source) { }
    public override InputFileType Type => InputFileType.Certificate;
}

public sealed class InputPhotoFile : InputFile
{
    public InputPhotoFile(string path) : base(path) { }
    public InputPhotoFile(InputFileSource source) : base(source) { }
    public override InputFileType Type => InputFileType.Photo;
}

public sealed class InputAudioFile : InputFile
{
    public InputAudioFile(string path) : base(path) { }
    public InputAudioFile(InputFileSource source) : base(source) { }
    public override InputFileType Type => InputFileType.Audio;
}

public sealed class InputDocumentFile : InputFile
{
    public InputDocumentFile(string path) : base(path) { }
    public InputDocumentFile(InputFileSource source) : base(source) { }
    public override InputFileType Type => InputFileType.Document;
}

public sealed class InputVideoFile : InputFile
{
    public InputVideoFile(string path) : base(path) { }
    public InputVideoFile(InputFileSource source) : base(source) { }
    public override InputFileType Type => InputFileType.Video;
}

public sealed class InputAnimationFile : InputFile
{
    public InputAnimationFile(string path) : base(path) { }
    public InputAnimationFile(InputFileSource source) : base(source) { }
    public override InputFileType Type => InputFileType.Animation;
}

public sealed class InputVoiceFile : InputFile
{
    public InputVoiceFile(string path) : base(path) { }
    public InputVoiceFile(InputFileSource source) : base(source) { }
    public override InputFileType Type => InputFileType.Voice;
}

public sealed class InputVideoNoteFile : InputFile
{
    public InputVideoNoteFile(string path) : base(path) { }
    public InputVideoNoteFile(InputFileSource source) : base(source) { }
    public override InputFileType Type => InputFileType.VideoNote;
}

public sealed class InputStickerFile : InputFile
{
    public InputStickerFile(string path) : base(path) { }
    public InputStickerFile(InputFileSource source) : base(source) { }
    public override InputFileType Type => InputFileType.Sticker;
}

public sealed class InputCoverFile : InputFile
{
    public InputCoverFile(string path) : base(path) { }
    public InputCoverFile(InputFileSource source) : base(source) { }
    public override InputFileType Type => InputFileType.Cover;
}

public sealed class InputThumbnailFile : InputFile
{
    public InputThumbnailFile(string path) : base(path) { }
    public InputThumbnailFile(InputFileSource source) : base(source) { }
    public override InputFileType Type => InputFileType.Thumbnail;
}
