using System.IO;
using Telegram.BotAPI.Enums;

namespace Telegram.BotAPI.Types;

public abstract class InputFile(string path)
{
    public abstract InputFileType Type { get; }

    public string FileName { get; } = Path.GetFileName(path);

    public Stream GetStream()
    {
        if (!File.Exists(path))
        {
            throw new FileNotFoundException(path);
        }

        return new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, useAsync: true);
    }
}

public sealed class InputCertificateFile(string path) : InputFile(path)
{
    public override InputFileType Type => InputFileType.Certificate;
}

public sealed class InputPhotoFile(string path) : InputFile(path)
{
    public override InputFileType Type => InputFileType.Photo;
}

public sealed class InputAudioFile(string path) : InputFile(path)
{
    public override InputFileType Type => InputFileType.Audio;
}

public sealed class InputDocumentFile(string path) : InputFile(path)
{
    public override InputFileType Type => InputFileType.Document;
}

public sealed class InputVideoFile(string path) : InputFile(path)
{
    public override InputFileType Type => InputFileType.Video;
}

public sealed class InputAnimationFile(string path) : InputFile(path)
{
    public override InputFileType Type => InputFileType.Animation;
}

public sealed class InputVoiceFile(string path) : InputFile(path)
{
    public override InputFileType Type => InputFileType.Voice;
}

public sealed class InputVideoNoteFile(string path) : InputFile(path)
{
    public override InputFileType Type => InputFileType.VideoNote;
}

public sealed class InputStickerFile(string path) : InputFile(path)
{
    public override InputFileType Type => InputFileType.Sticker;
}

public sealed class InputCoverFile(string path) : InputFile(path)
{
    public override InputFileType Type => InputFileType.Cover;
}

public sealed class InputThumbnailFile(string path) : InputFile(path)
{
    public override InputFileType Type => InputFileType.Thumbnail;
}
